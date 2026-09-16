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
7. PRODUCT TAB FILTERING (Home Page with Swipe)
========================================================================== */
function initProductTabs() {
    const tabs = document.querySelectorAll('.ns-filter-tab');
    const container = document.getElementById('featured-products-container');

    if (tabs.length === 0 || !container) return;

    // Give the container its base starting classes
    container.classList.add('ns-grid-transition', 'ns-swipe-ready');

    tabs.forEach(tab => {
        tab.addEventListener('click', async () => {
            // Stop if they click the tab that is already active
            if (tab.classList.contains('active')) return;

            // Update the active button
            tabs.forEach(t => t.classList.remove('active'));
            tab.classList.add('active');
            
            const targetFilter = tab.getAttribute('data-filter');
            
            // 1. Trigger the "Swipe Out" animation
            container.classList.remove('ns-swipe-ready');
            container.classList.add('ns-swipe-out');
            
            try {
                // 2. Fetch the data quietly in the background while it animates
                const response = await fetch(`/Home/GetFilteredProducts?filter=${targetFilter}`);
                if (!response.ok) throw new Error('Network response was not ok');
                const html = await response.text();
                
                // 3. Wait exactly 300ms for the slide-out CSS to finish
                setTimeout(() => {
                    // Inject the new products
                    container.innerHTML = html;
                    
                    // Instantly snap the container invisibly to the right side
                    container.classList.remove('ns-swipe-out');
                    container.classList.add('ns-swipe-in');
                    
                    // Force the browser to register the new position (a required JS trick)
                    void container.offsetWidth; 
                    
                    // 4. Trigger the "Swipe In" animation
                    container.classList.remove('ns-swipe-in');
                    container.classList.add('ns-swipe-ready');
                    
                }, 300); // This number must match the 0.3s in your CSS
                
            } catch (error) {
                console.error('Error fetching products:', error);
                setTimeout(() => {
                    container.innerHTML = '<div class="col-12 text-center text-danger py-5">Failed to load products.</div>';
                    container.classList.remove('ns-swipe-out', 'ns-swipe-in');
                    container.classList.add('ns-swipe-ready');
                }, 300);
            }
        });
    });
}


/* ==========================================================================
    8. PRODUCT FILTERS & SORT (Products/Index page)
    ========================================================================== */
    function initProductFilters() {
        const productGrid = document.getElementById('productGrid');
        if (!productGrid) return; // Exit silently if not on the shop page

        const searchInput = document.getElementById('searchInput');
        const sortSelect = document.getElementById('sortSelect');
        const priceRange = document.getElementById('priceRange');
        const priceRangeValue = document.getElementById('priceRangeValue');
        const inStockSwitch = document.getElementById('inStockSwitch');
        const applyBtn = document.getElementById('applyFiltersBtn');
        const clearBtn = document.getElementById('clearFiltersBtn');
        const visibleCount = document.getElementById('visibleCount');
        const noResultsMsg = document.getElementById('noResultsMsg');
        
        const allCards = Array.from(productGrid.querySelectorAll('.product-item'));

        function applyFiltersAndSort() {
            const query = searchInput ? searchInput.value.trim().toLowerCase() : '';
            const maxPrice = priceRange ? parseInt(priceRange.value) : Infinity;
            const absoluteMaxSliderValue = priceRange ? parseInt(priceRange.max) : Infinity;
            const onlyInStock = inStockSwitch ? inStockSwitch.checked : false;

            const selectedCategories = Array.from(document.querySelectorAll('.filter-category:checked')).map(cb => cb.value);
            const selectedBrands = Array.from(document.querySelectorAll('.filter-brand:checked')).map(cb => cb.value);

            let visibleCards = [];

            allCards.forEach(card => {
                const name = card.dataset.name || '';
                const price = parseFloat(card.dataset.price) || 0;
                const category = card.dataset.category || '';
                const brand = card.dataset.brand || '';
                const inStock = card.dataset.instock === '1';

                let show = true;

                // Check filters
                if (query && !name.includes(query)) show = false;
                // Only filter by price if slider is not at maximum
                if (maxPrice < absoluteMaxSliderValue && price > maxPrice) show = false;
                if (selectedCategories.length > 0 && !selectedCategories.includes(category)) show = false;
                if (selectedBrands.length > 0 && !selectedBrands.includes(brand)) show = false;
                if (onlyInStock && !inStock) show = false;

                card.style.display = show ? '' : 'none';
                if (show) visibleCards.push(card);
            });

            // Update UI
            if (visibleCount) visibleCount.textContent = visibleCards.length;
            if (noResultsMsg) noResultsMsg.classList.toggle('d-none', visibleCards.length > 0);

            // Re-sort the remaining cards
            sortCards(visibleCards);
        }

        function sortCards(cards) {
            if (!sortSelect) return;
            const sortValue = sortSelect.value;

            const sorted = [...cards].sort((a, b) => {
                switch (sortValue) {
                    case 'price-asc': return (parseFloat(a.dataset.price) || 0) - (parseFloat(b.dataset.price) || 0);
                    case 'price-desc': return (parseFloat(b.dataset.price) || 0) - (parseFloat(a.dataset.price) || 0);
                    case 'rating-desc': return (parseFloat(b.dataset.rating) || 0) - (parseFloat(a.dataset.rating) || 0);
                    case 'new': return (parseInt(b.dataset.created) || 0) - (parseInt(a.dataset.created) || 0);
                    case 'featured':
                    default: return (parseInt(b.dataset.featured) || 0) - (parseInt(a.dataset.featured) || 0);
                }
            });

            // Re-append to grid in sorted order
            sorted.forEach(card => productGrid.appendChild(card));
        }

        // Wire up event listeners
        if (sortSelect) sortSelect.addEventListener('change', applyFiltersAndSort);
        if (applyBtn) applyBtn.addEventListener('click', applyFiltersAndSort);
        if (priceRange) {
            priceRange.addEventListener('input', function () {
                const val = parseInt(priceRange.value);
                const max = parseInt(priceRange.max);
                priceRangeValue.textContent = val >= max ? `$${max}+` : `$${val}`;
            });
        }
        if (clearBtn) {
            clearBtn.addEventListener('click', function () {
                if (searchInput) searchInput.value = '';
                if (priceRange) { 
                    priceRange.value = priceRange.max; 
                    priceRangeValue.textContent = `$${priceRange.max}+`; 
                }
                if (inStockSwitch) inStockSwitch.checked = false;
                document.querySelectorAll('.filter-category:checked, .filter-brand:checked').forEach(cb => cb.checked = false);
                if (sortSelect) sortSelect.value = 'featured';
                applyFiltersAndSort();
            });
        }

        // Initial sort on load
        sortCards(allCards);
    }

    /* ==========================================================================
    9. QUICK VIEW MODAL FETCH LOGIC
    ========================================================================== */
    // Note: Removed the redundant DOMContentLoaded wrapper since the whole file is wrapped
    const quickViewButtons = document.querySelectorAll('.ns-btn-quick-view');
    const modalContainer = document.getElementById('quickViewModalContainer');

    if (modalContainer && quickViewButtons.length > 0) {
        quickViewButtons.forEach(button => {
            button.addEventListener('click', async function (e) {
                e.preventDefault(); 
                const productId = this.getAttribute('data-id');
                if (!productId) return;

                const originalIcon = this.innerHTML;
                this.innerHTML = '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>';
                this.disabled = true;

                try {
                    const response = await fetch(`/Products/QuickReview/${productId}`);
                    if (!response.ok) throw new Error('Failed to fetch product data');
                    
                    const html = await response.text();
                    modalContainer.innerHTML = html;
                    
                    const modalElement = document.getElementById('quickViewModal');
                    const bootstrapModal = new bootstrap.Modal(modalElement);
                    bootstrapModal.show();
                } catch (error) {
                    console.error('Error:', error);
                    alert('Could not load product details. Please try again.');
                } finally {
                    this.innerHTML = originalIcon;
                    this.disabled = false;
                }
            });
        });
    }

    /* ==========================================================================
    10. PRODUCT DETAILS PAGE SPECIFICS
    ========================================================================== */
    // Image gallery swipe
    document.querySelectorAll('.ns-thumbnail').forEach(img => {
        img.addEventListener('click', function() {
            const mainImage = document.getElementById('mainImage');
            if (mainImage) mainImage.src = this.src;
        });
    });

    // Color selector label update
    document.querySelectorAll('.color-selector').forEach(radio => {
        radio.addEventListener('change', function() {
            const colorName = this.getAttribute('data-color-name');
            const label = document.getElementById('colorTextLabel'); 
            if (label) {
                label.innerHTML = `Color: <span class="fw-normal text-body ms-1">${colorName}</span>`;
            }
        });
    });

    /* ==========================================================================
    11. HOME PAGE CATEGORY SCROLL
    ========================================================================== */
    window.scrollCategories = function(direction) {
        const container = document.getElementById('categoryScroll');
        if (container) {
            const scrollAmount = container.clientWidth / 2; 
            container.scrollBy({
                left: direction * scrollAmount,
                behavior: 'smooth'
            });
        }
    };


    /*==================orders page admin====================*/


    (function () {
    // ---- Filter bar toggle ----
    var toggleBtn = document.getElementById('toggleFiltersBtn');
    var filterBar = document.getElementById('ordersFilterBar');
    var toggleLabel = document.getElementById('toggleFiltersLabel');
    if (toggleBtn && filterBar) {
        toggleBtn.addEventListener('click', function () {
            var hidden = filterBar.style.display === 'none';
            filterBar.style.display = hidden ? 'flex' : 'none';
            toggleLabel.textContent = hidden ? 'Hide filters' : 'Show filters';
        });
    }

    // ---- Client-side pagination ----
    var pageSize   = pageSize;
    var totalItems = totalItemsCount;
    var totalPages = totalPages;
    var currentPage = 1;

    var rows        = document.querySelectorAll('#ordersTableBody tr[data-page]');
    var pageButtons = document.querySelectorAll('.page-num-btn');
    var pageInfo    = document.getElementById('pageInfoText');

    function showPage(page) {
        if (page < 1) page = 1;
        if (page > totalPages) page = totalPages;
        currentPage = page;

        rows.forEach(function (row) {
            row.style.display = (parseInt(row.getAttribute('data-page'), 10) === currentPage) ? '' : 'none';
        });

        pageButtons.forEach(function (btn) {
            btn.classList.toggle('active', parseInt(btn.getAttribute('data-page'), 10) === currentPage);
        });

        var start = totalItems === 0 ? 0 : (currentPage - 1) * pageSize + 1;
        var end   = Math.min(currentPage * pageSize, totalItems);
        if (pageInfo) pageInfo.textContent = start + '-' + end + ' out of ' + totalItems + ' orders';
    }

    pageButtons.forEach(function (btn) {
        btn.addEventListener('click', function () {
            showPage(parseInt(btn.getAttribute('data-page'), 10));
        });
    });

    var bind = function (id, fn) {
        var el = document.getElementById(id);
        if (el) el.addEventListener('click', fn);
    };
    bind('prevPageBtn',  function () { showPage(currentPage - 1); });
    bind('nextPageBtn',  function () { showPage(currentPage + 1); });
    bind('firstPageBtn', function () { showPage(1); });
    bind('lastPageBtn',  function () { showPage(totalPages); });

    showPage(1);
})();