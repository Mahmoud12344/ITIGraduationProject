/**
 * NiceShop — Admin JavaScript
 * Handles admin specific interactions like stock adjustments, status toggles, and image preview.
 */

document.addEventListener('DOMContentLoaded', function () {
    // Admin theme uses the exact same logic as storefront (initTheme is in niceshop.js)
    // We assume niceshop.js is also loaded in _AdminLayout, or we duplicate the initTheme logic here.
    initAdminConfirmations();
});

window.nsAdmin = {
    updateStock: function (productId, change) {
        // Implement AJAX POST to /Admin/UpdateStock
        console.log(`Update stock for ${productId} by ${change}`);
        // Mock success (find the input and update it)
        const input = document.getElementById(`stock-${productId}`);
        if (input) {
            let current = parseInt(input.value) || 0;
            current = Math.max(0, current + change);
            input.value = current;
            window.nsToast.show('Stock updated successfully');
        }
    },
    
    toggleProductActive: function (btnElement, productId) {
        // Implement AJAX POST to /Admin/ToggleProductActive
        console.log(`Toggle active for ${productId}`);
        
        const isActive = btnElement.classList.contains('is-active');
        if (isActive) {
            btnElement.classList.remove('is-active');
            btnElement.classList.add('is-hidden');
            btnElement.innerHTML = 'Hidden';
            window.nsToast.show('Product is now hidden', 'info');
        } else {
            btnElement.classList.remove('is-hidden');
            btnElement.classList.add('is-active');
            btnElement.innerHTML = 'Active';
            window.nsToast.show('Product is now active');
        }
    },

    updateOrderStatus: function (orderId, selectElement) {
        const newStatus = selectElement.value;
        // Implement AJAX POST to /Admin/UpdateOrderStatus
        console.log(`Order ${orderId} status changed to ${newStatus}`);
        window.nsToast.show(`Order status updated to ${newStatus}`);
    },

    toggleReviewVisibility: function (btnElement, reviewId) {
        // Implement AJAX POST to /Admin/ToggleReviewVisibility
        const isHidden = btnElement.textContent.includes('Approve');
        if (isHidden) {
            btnElement.textContent = 'Hide';
            btnElement.classList.replace('btn-ns-primary', 'btn-ns-outline');
            window.nsToast.show('Review approved and is now visible');
        } else {
            btnElement.textContent = 'Approve';
            btnElement.classList.replace('btn-ns-outline', 'btn-ns-primary');
            window.nsToast.show('Review hidden', 'info');
        }
    },
    
    previewImage: function (inputElement, previewImgId) {
        const preview = document.getElementById(previewImgId);
        if (!preview) return;
        
        if (inputElement.files && inputElement.files[0]) {
            const reader = new FileReader();
            reader.onload = function(e) {
                preview.src = e.target.result;
            }
            reader.readAsDataURL(inputElement.files[0]);
        }
    }
};

function initAdminConfirmations() {
    // Attach confirmation dialog to any button with data-confirm
    const confirmBtns = document.querySelectorAll('[data-confirm]');
    confirmBtns.forEach(btn => {
        btn.addEventListener('click', function(e) {
            const message = btn.getAttribute('data-confirm');
            if (!confirm(message)) {
                e.preventDefault();
            }
        });
    });
}
