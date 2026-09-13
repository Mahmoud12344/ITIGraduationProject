/**
 * NiceShop — Main Storefront JavaScript
 * Handles theme toggle, toasts, offcanvas cart, search, and flash sale countdown.
 */

document.addEventListener('DOMContentLoaded', function () {
    initTheme();
    initFlashSaleCountdown();
    initSearchSuggestions();
    initProductTabs();
    initProductFilters();
});

/* ==========================================================================
   1. THEME TOGGLE (Light/Dark Mode)
   ========================================================================== */
function initTheme() {
    const themeToggles = document.querySelectorAll('.ns-theme-toggle');
    const htmlEl = document.documentElement;
    
    // Check local storage first, then system preference
    const savedTheme = localStorage.getItem('niceshop_theme');
    const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
    
    let currentTheme = 'light';
    if (savedTheme) {
        currentTheme = savedTheme;
    } else if (prefersDark) {
        currentTheme = 'dark';
    }

    if (currentTheme === 'dark') {
        htmlEl.setAttribute('data-theme', 'dark');
        updateToggleIcons('dark');
    }

    // Toggle handler
    themeToggles.forEach(toggle => {
        toggle.addEventListener('click', () => {
            const isDark = htmlEl.getAttribute('data-theme') === 'dark';
            const newTheme = isDark ? 'light' : 'dark';
            
            if (newTheme === 'dark') {
                htmlEl.setAttribute('data-theme', 'dark');
            } else {
                htmlEl.removeAttribute('data-theme');
            }
            
            localStorage.setItem('niceshop_theme', newTheme);
            updateToggleIcons(newTheme);
        });
    });

    function updateToggleIcons(theme) {
        themeToggles.forEach(btn => {
            const icon = btn.querySelector('i');
            if (icon) {
                if (theme === 'dark') {
                    icon.classList.remove('bi-moon');
                    icon.classList.add('bi-sun');
                } else {
                    icon.classList.remove('bi-sun');
                    icon.classList.add('bi-moon');
                }
            }
        });
    }
}

/* ==========================================================================
   2. TOAST NOTIFICATIONS
   ========================================================================== */
window.nsToast = {
    show: function (message, type = 'success') {
        const container = document.getElementById('ns-toast-container');
        if (!container) return;

        const toastEl = document.createElement('div');
        toastEl.className = `ns-toast ns-toast-${type} mb-2`;
        
        let iconClass = 'bi-check-circle-fill';
        if (type === 'error') iconClass = 'bi-exclamation-triangle-fill';
        if (type === 'info') iconClass = 'bi-info-circle-fill';

        toastEl.innerHTML = `<i class="bi ${iconClass}"></i> <span>${message}</span>`;
        container.appendChild(toastEl);

        // Auto remove after 3.5 seconds
        setTimeout(() => {
            toastEl.style.opacity = '0';
            toastEl.style.transform = 'translateX(20px)';
            toastEl.style.transition = 'all 0.3s ease';
            setTimeout(() => {
                if (container.contains(toastEl)) {
                    container.removeChild(toastEl);
                }
            }, 300);
        }, 3500);

        // Click to dismiss
        toastEl.addEventListener('click', () => {
            toastEl.style.opacity = '0';
            setTimeout(() => {
                if (container.contains(toastEl)) container.removeChild(toastEl);
            }, 300);
        });
    }
};

/* ==========================================================================
   3. CART OPERATIONS & WISHLIST
   ========================================================================== */
// Expose functions globally for inline onclick handlers if needed
window.nsCart = {
    updateQuantity: function(productId, size, color, change) {
        // Implement AJAX call to /Cart/UpdateQuantity
        console.log(`Update ${productId} by ${change}`);
        // Mock success:
        // window.location.reload();
    },
    removeItem: function(productId, size, color) {
        // Implement AJAX call to /Cart/Remove
        console.log(`Remove ${productId}`);
    },
    toggleWishlist: function(btnElement, productId) {
        // Implement AJAX call to /Wishlist/Toggle
        const isAdded = !btnElement.classList.contains('active');
        btnElement.classList.toggle('active');
        
        if (isAdded) {
            window.nsToast.show('Added to your wishlist!');
        } else {
            window.nsToast.show('Removed from your wishlist', 'info');
        }
    }
};

/* ==========================================================================
   4. QUICK VIEW MODAL
   ========================================================================== */
window.nsQuickView = {
    open: function(productId) {
        console.log('Fetching details for', productId);
        // 1. Show loading state in modal
        // 2. Fetch /Products/QuickView/{productId} via AJAX
        // 3. Populate modal content
        // 4. Show modal via Bootstrap JS
        const myModal = new bootstrap.Modal(document.getElementById('quickViewModal'));
        myModal.show();
    }
};

/* ==========================================================================
   5. SEARCH SUGGESTIONS
   ========================================================================== */
function initSearchSuggestions() {
    const searchInput = document.getElementById('nav-search-input');
    const dropdown = document.getElementById('nav-search-dropdown');
    if (!searchInput || !dropdown) return;

    let timeout = null;

    searchInput.addEventListener('input', function(e) {
        const query = e.target.value.trim();
        clearTimeout(timeout);
        
        if (query.length < 2) {
            dropdown.classList.add('d-none');
            return;
        }

        timeout = setTimeout(() => {
            // Mocking AJAX call to /Products/Search?q=query
            dropdown.classList.remove('d-none');
            dropdown.innerHTML = `
                <div class="ns-suggestion-item" onclick="window.location='/Products/Details/mock'">
                    <img src="https://images.unsplash.com/photo-1539533018447-63fcce2678e3?w=50" alt="" width="40" height="50" style="object-fit: cover; border-radius: 4px;">
                    <div>
                        <div class="ns-card-title m-0" style="font-size:0.75rem;">Double-Breasted Cashmere Trench...</div>
                        <div class="ns-card-price" style="font-size:0.75rem;">$490</div>
                    </div>
                </div>
                <div class="ns-suggestion-item" onclick="window.location='/Products?q=${query}'">
                    <div style="font-size:0.75rem; font-weight:600; color:var(--ns-text-muted);">See all results for "${query}"</div>
                </div>
            `;
        }, 300);
    });

    // Close on click outside
    document.addEventListener('click', function(e) {
        if (!searchInput.contains(e.target) && !dropdown.contains(e.target)) {
            dropdown.classList.add('d-none');
        }
    });
}

/* ==========================================================================
   6. FLASH SALE COUNTDOWN (Home Page)
   ========================================================================== */
function initFlashSaleCountdown() {
    const elH = document.getElementById('sale-h');
    const elM = document.getElementById('sale-m');
    const elS = document.getElementById('sale-s');
    
    if (!elH || !elM || !elS) return;

    function update() {
        // Mock 4 hours remaining from now (you would pass actual end date from ViewModel)
        const now = new Date();
        const end = new Date();
        end.setHours(now.getHours() + 4);
        end.setMinutes(45);
        end.setSeconds(30);
        
        const diff = end - new Date();
        if (diff <= 0) return; // Sale ended

        const h = Math.floor(diff / (1000 * 60 * 60));
        const m = Math.floor((diff / 1000 / 60) % 60);
        const s = Math.floor((diff / 1000) % 60);

        elH.textContent = h.toString().padStart(2, '0');
        elM.textContent = m.toString().padStart(2, '0');
        elS.textContent = s.toString().padStart(2, '0');
    }

    update();
    setInterval(update, 1000);
}

/* ==========================================================================
   7. PRODUCT TAB FILTERING (Home Page)
   ========================================================================== */
function initProductTabs() {
    const tabs = document.querySelectorAll('.ns-filter-tab');
    if (tabs.length === 0) return;

    tabs.forEach(tab => {
        tab.addEventListener('click', () => {
            // Remove active class from all
            tabs.forEach(t => t.classList.remove('active'));
            // Add to clicked
            tab.classList.add('active');
            
            const targetFilter = tab.getAttribute('data-filter');
            
            // In a real MVC app, you might trigger an AJAX call here to fetch a PartialView
            // and replace the contents of a div.
            console.log('Filtering home products by:', targetFilter);
        });
    });
}

/* ==========================================================================
   8. PRODUCT FILTERS & SORT (Products/Index page)
   ========================================================================== */
function initProductFilters() {
    const productGrid = document.getElementById('productGrid');
    if (!productGrid) return; // Not on the Products page — exit silently

    const sortSelect = document.getElementById('sortSelect');
    const searchInput = document.getElementById('searchInput');
    const priceRange = document.getElementById('priceRange');
    const priceRangeValue = document.getElementById('priceRangeValue');
    const inStockSwitch = document.getElementById('inStockSwitch');
    const applyBtn = document.getElementById('applyFiltersBtn');
    const clearBtn = document.getElementById('clearFiltersBtn');
    const visibleCount = document.getElementById('visibleCount');
    const noResultsMsg = document.getElementById('noResultsMsg');
    const allCards = [...productGrid.querySelectorAll('.product-item')];

    function applyFiltersAndSort() {
        const query = searchInput ? searchInput.value.trim().toLowerCase() : '';
        const maxPrice = priceRange ? parseInt(priceRange.value) : Infinity;
        const onlyInStock = inStockSwitch ? inStockSwitch.checked : false;

        const selectedCategories = [...document.querySelectorAll('.filter-category:checked')].map(cb => cb.value);
        const selectedBrands = [...document.querySelectorAll('.filter-brand:checked')].map(cb => cb.value);

        let visible = 0;

        allCards.forEach(card => {
            const name = card.dataset.name || '';
            const price = parseFloat(card.dataset.price) || 0;
            const category = card.dataset.category || '';
            const brand = card.dataset.brand || '';
            const inStock = card.dataset.instock === '1';

            let show = true;

            // Text search
            if (query && !name.includes(query)) show = false;

            // Price filter
            if (price > maxPrice) show = false;

            // Category filter
            if (selectedCategories.length > 0 && !selectedCategories.includes(category)) show = false;

            // Brand filter
            if (selectedBrands.length > 0 && !selectedBrands.includes(brand)) show = false;

            // In-stock filter
            if (onlyInStock && !inStock) show = false;

            card.style.display = show ? '' : 'none';
            if (show) visible++;
        });

        // Update visible count
        if (visibleCount) visibleCount.textContent = visible;

        // Show/hide "no results" message
        if (noResultsMsg) {
            noResultsMsg.classList.toggle('d-none', visible > 0);
        }

        // Sort the visible cards
        sortCards(allCards);
    }

    function sortCards(cards) {
        if (!sortSelect) return;
        const sortValue = sortSelect.value;

        const sorted = [...cards].sort((a, b) => {
            switch (sortValue) {
                case 'price-asc':
                    return (parseFloat(a.dataset.price) || 0) - (parseFloat(b.dataset.price) || 0);
                case 'price-desc':
                    return (parseFloat(b.dataset.price) || 0) - (parseFloat(a.dataset.price) || 0);
                case 'rating-desc':
                    return (parseFloat(b.dataset.rating) || 0) - (parseFloat(a.dataset.rating) || 0);
                case 'new':
                    return (parseInt(b.dataset.created) || 0) - (parseInt(a.dataset.created) || 0);
                case 'featured':
                default:
                    return (parseInt(b.dataset.featured) || 0) - (parseInt(a.dataset.featured) || 0);
            }
        });

        sorted.forEach(card => productGrid.appendChild(card));
    }

    // Wire up event listeners
    if (sortSelect) {
        sortSelect.addEventListener('change', applyFiltersAndSort);
    }
    if (priceRange) {
        priceRange.addEventListener('input', function () {
            const val = parseInt(priceRange.value);
            priceRangeValue.textContent = val >= 2000 ? '$2,000+' : `$${val}`;
        });
    }
    if (applyBtn) {
        applyBtn.addEventListener('click', applyFiltersAndSort);
    }
    if (clearBtn) {
        clearBtn.addEventListener('click', function () {
            if (searchInput) searchInput.value = '';
            if (priceRange) { priceRange.value = 2000; priceRangeValue.textContent = '$2,000+'; }
            if (inStockSwitch) inStockSwitch.checked = false;
            document.querySelectorAll('.filter-category:checked, .filter-brand:checked').forEach(cb => cb.checked = false);
            if (sortSelect) sortSelect.value = 'featured';
            applyFiltersAndSort();
        });
    }

    // Initial sort on page load
    sortCards(allCards);
}