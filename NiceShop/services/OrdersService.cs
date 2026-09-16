using System.Net.Quic;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NiceShop.Data;
using NiceShop.Models;
using NiceShop.ViewModels.Admin;

namespace NiceShop.services;

public class OrdersService(ApplicationDbContext context)
{
    
        public async Task<List<OrdersVm.OrderSummaryVm>> GetOrdersAsync(OrdersVm.OrderFilterVm filter)
        {
                var query = context.Orders.Include(o => o.Address)
                .Include(o => o.Coupon).Include(o=>o.Customer).ThenInclude(c=>c.ApplicationUser)
                .Include(o=>o.OrderItems).AsQueryable();

                

                if(!string.IsNullOrWhiteSpace(filter.SearchQuery))
                {
                        query = query.Where(o=>o.Number.Contains(filter.SearchQuery)
                         || o.Customer.ApplicationUser!.UserName!.Contains(filter.SearchQuery));
                }

                if(filter.StartDate.HasValue)
                {
                        query = query.Where(o=>o.OrderDate >= filter.StartDate.Value);
                }
                if(filter.EndDate.HasValue)
                {
                        var end = filter.EndDate.Value.Date.AddDays(1);

                        query = query.Where(o=>o.OrderDate < end);
                }


                if(filter.Status.HasValue)
                {
                        query = query.Where(o => o.Status == filter.Status.Value);
                }

                return await query.Select(o => new OrdersVm.OrderSummaryVm
                {
                        Id = o.Id,
                        Number = o.Number,
                        CustomerName = (o.Customer != null && o.Customer.ApplicationUser != null) 
                        ? o.Customer.ApplicationUser.UserName! 
                        : "Unknown Customer",
                        OrderDate = o.OrderDate,
                        Total = o.Total,
                        Status = o.Status
                }).ToListAsync();
        }


        public async Task<OrdersVm.OrderDetailsVm> GetOrderDetailsAsync(int? Id)
        {
                var order = await context.Orders
                                .Include(o=>o.Address).Include(o=>o.Coupon)
                                .Include(o=>o.Customer).ThenInclude(c=>c.ApplicationUser)
                                .Include(o=>o.OrderItems)
                                .FirstOrDefaultAsync(o=>o.Id == Id);

                return new OrdersVm.OrderDetailsVm
                {
                        Id = order!.Id, 
                        Number = order.Number,
                        OrderDate = order.OrderDate, 
                        Status = order.Status, 

                        ShippingAddress = $" {order.Address.Building}, {order.Address.Street}, {order.Address.City}, {order.Address.Government} ({order.Address.AddressType})",


                        CustomerName = order.Customer.ApplicationUser?.UserName ?? "Unknown Customer",
                        CustomerEmail = order.Customer?.ApplicationUser?.Email ?? "No Email",

                        Subtotal = order.Subtotal, 
                        ShippingCost = order.ShippingCost, 
                        Discount = order.Discount,
                        Total = order.Total,

                        CouponId = order.CouponId,
                        CouponCode = order.Coupon?.Code,

                        Notes = order.Notes, 
                        IsCanceled = order.IsCanceled,
                        CancellationReason = order.CancellationReason,

                        Items = order.OrderItems.Select( i => new OrdersVm.OrderItemVm
                        {
                            ProductId = i.ProductId,
                            Name = i.Name,
                            Price = i.Price,
                            Quantity = i.Quantity,
                            Size = i.Size,
                            Color = i.Color

                        }).ToList()
                };
        }

        public async Task<bool> UpdateOrderStatusAsync(int Id, OrderStatus status)
        {
                var order =  await context.Orders.FindAsync(Id);
                if(order == null) return false;

                if (order.Status == OrderStatus.Delivered || order.Status == OrderStatus.Cancelled)
                        return false;

                order.Status = status;
 
                if (status == OrderStatus.Cancelled)
                        order.IsCanceled = true;
                        
                await context.SaveChangesAsync();
                return true;

        }

}