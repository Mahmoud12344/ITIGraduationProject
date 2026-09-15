using System.Net.Quic;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NiceShop.Data;
using NiceShop.Models;
using NiceShop.ViewModels.Admin;

namespace NiceShop.services;

public class OrdersService(ApplicationDbContext context)
{
    
        public async Task<List<Order>> GetOrdersAsync(OrderFilterVm filter)
        {
                var query = context.Orders.Include(o => o.Address)
                .Include(o => o.Coupon).Include(o=>o.Customer)
                .Include(o=>o.OrderItems).AsQueryable();

                if(filter.Status!=null)
                {
                        query = query.Where(o => o.Status == filter.Status);
                }

                if(!string.IsNullOrWhiteSpace(filter.SearchQuery))
                {
                        query = query.Where(o=>o.Number.Contains(filter.SearchQuery));
                }

                if(filter.StartDate!=null)
                {
                        query = query.Where(o=>o.OrderDate >= filter.StartDate);
                }
                if(filter.EndDate!=null)
                {
                        query = query.Where(o=>o.OrderDate <= filter.EndDate);
                }

                return await query.ToListAsync();
        }


        public async Task<Order?> GetOrderDetailsAsync(int Id)
        {
                var order = await context.Orders
                                .Include(o=>o.Address).Include(o=>o.Coupon)
                                .Include(o=>o.Customer).Include(o=>o.OrderItems)
                                .FirstOrDefaultAsync(o=>o.Id == Id);

                return order;
        }

        public async Task<Order?> UpdateOrderStatusAsync(int Id, OrderStatus status)
        {
                var order =  context.Orders.Find(Id);

                if(order.Status < status)
                {
                        order.Status = status;
                        await context.SaveChangesAsync();
                }

                return order;
        }

}