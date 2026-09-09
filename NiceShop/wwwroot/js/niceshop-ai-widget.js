/**
 * NiceShop — AI Stylist Widget JavaScript
 * Handles chat interactions, typing indicators, and AJAX calls to the .NET backend.
 */

document.addEventListener('DOMContentLoaded', function () {
    initAIWidget();
});

function initAIWidget() {
    const triggerBtn = document.getElementById('ai-trigger-btn');
    const windowEl = document.getElementById('ai-window');
    const closeBtn = document.getElementById('ai-close-btn');
    const minBtn = document.getElementById('ai-min-btn');
    const resetBtn = document.getElementById('ai-reset-btn');
    const sendBtn = document.getElementById('ai-send-btn');
    const inputEl = document.getElementById('ai-input');
    const messagesArea = document.getElementById('ai-messages-area');
    const suggestions = document.querySelectorAll('.ns-ai-suggestion-pill');
    const badge = document.getElementById('ai-unread-badge');

    if (!triggerBtn || !windowEl) return;

    let isMinimized = true;
    let isTyping = false;
    let hasUnread = true; // Start with unread welcome message

    // --- Window Toggles ---
    triggerBtn.addEventListener('click', () => {
        if (windowEl.classList.contains('d-none') || isMinimized) {
            windowEl.classList.remove('d-none');
            windowEl.classList.remove('minimized');
            isMinimized = false;
            // Clear badge
            badge.textContent = '';
            badge.classList.add('d-none');
            hasUnread = false;
            scrollToBottom();
        } else {
            windowEl.classList.add('minimized');
            isMinimized = true;
        }
    });

    closeBtn.addEventListener('click', () => {
        windowEl.classList.add('d-none');
        isMinimized = true;
    });

    minBtn.addEventListener('click', () => {
        windowEl.classList.add('minimized');
        isMinimized = true;
    });

    // --- Chat Reset ---
    resetBtn.addEventListener('click', () => {
        if (confirm('Clear chat history?')) {
            // Keep only the welcome message
            const welcomeMsg = messagesArea.querySelector('.ns-ai-welcome');
            messagesArea.innerHTML = '';
            if (welcomeMsg) messagesArea.appendChild(welcomeMsg);
            
            // Re-add suggestions
            const suggContainer = document.querySelector('.ns-ai-suggestions');
            if (suggContainer) {
                suggContainer.style.display = 'flex';
            }
        }
    });

    // --- Sending Messages ---
    function sendMessage(text) {
        if (!text || text.trim() === '') return;
        
        // Hide suggestions after first message
        const suggContainer = document.querySelector('.ns-ai-suggestions');
        if (suggContainer) {
            suggContainer.style.display = 'none';
        }

        // Add user message
        addUserMessage(text);
        inputEl.value = '';
        inputEl.disabled = true;
        sendBtn.disabled = true;
        
        // Show typing indicator
        showTypingIndicator();

        // ---------------------------------------------------------
        // TODO for backend developer: Wire this up to your API
        // ---------------------------------------------------------
        /*
        fetch('/api/AI/Chat', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ message: text })
        })
        .then(res => res.json())
        .then(data => {
            hideTypingIndicator();
            addAIMessage(data.reply, data.products);
        })
        .catch(err => {
            hideTypingIndicator();
            addAIMessage("I'm sorry, I'm having trouble connecting right now. Please try again later.");
        });
        */

        // MOCK RESPONSE FOR TEMPLATE PREVIEW:
        setTimeout(() => {
            hideTypingIndicator();
            inputEl.disabled = false;
            sendBtn.disabled = false;
            inputEl.focus();

            const mockReply = "Based on what you're looking for, I'd highly recommend our Cashmere Trench Coat. It's incredibly versatile and perfect for this season.";
            
            const mockProducts = [
                {
                    id: 'prod-1',
                    name: 'Double-Breasted Cashmere Trench Coat',
                    price: '$490',
                    image: 'https://images.unsplash.com/photo-1539533018447-63fcce2678e3?w=300'
                }
            ];

            addAIMessage(mockReply, text.toLowerCase().includes('coat') ? mockProducts : []);

            if (isMinimized) {
                badge.textContent = '1';
                badge.classList.remove('d-none');
            }
        }, 1500);
    }

    sendBtn.addEventListener('click', () => sendMessage(inputEl.value));
    
    inputEl.addEventListener('keypress', (e) => {
        if (e.key === 'Enter') {
            e.preventDefault();
            sendMessage(inputEl.value);
        }
    });

    // --- Suggestion Pills ---
    suggestions.forEach(pill => {
        pill.addEventListener('click', () => {
            sendMessage(pill.textContent);
        });
    });

    // --- UI Helpers ---
    function addUserMessage(text) {
        const html = `
            <div class="ns-ai-bubble-user ns-animate-fadeIn">
                <div class="ns-ai-bubble-content">${escapeHTML(text)}</div>
            </div>
        `;
        messagesArea.insertAdjacentHTML('beforeend', html);
        scrollToBottom();
    }

    function addAIMessage(text, products = []) {
        let productsHtml = '';
        if (products && products.length > 0) {
            productsHtml = `<div class="ns-ai-products mt-2">`;
            products.forEach(p => {
                productsHtml += `
                    <div class="ns-ai-product-card">
                        <img src="${p.image}" alt="${escapeHTML(p.name)}">
                        <div class="ns-ai-product-info">
                            <div class="ns-ai-product-name">${escapeHTML(p.name)}</div>
                            <div class="ns-ai-product-price">${p.price}</div>
                            <div class="ns-ai-product-actions">
                                <button onclick="window.nsQuickView && window.nsQuickView.open('${p.id}')">Quick View</button>
                                <a href="/Products/Details/${p.id}">View</a>
                            </div>
                        </div>
                    </div>
                `;
            });
            productsHtml += `</div>`;
        }

        const html = `
            <div class="ns-ai-bubble-ai ns-animate-fadeIn">
                <div class="ns-ai-avatar"><i class="bi bi-stars"></i></div>
                <div class="ns-ai-bubble-content w-100">
                    ${text}
                    ${productsHtml}
                </div>
            </div>
        `;
        messagesArea.insertAdjacentHTML('beforeend', html);
        scrollToBottom();
    }

    let typingEl = null;
    function showTypingIndicator() {
        typingEl = document.createElement('div');
        typingEl.className = 'ns-ai-typing ns-animate-fadeIn mt-2';
        typingEl.innerHTML = `
            <div class="ns-ai-avatar" style="width:1.5rem;height:1.5rem;background:linear-gradient(135deg, #fbbf24, #f59e0b);border-radius:0.375rem;display:flex;align-items:center;justify-content:center;font-size:0.6875rem;"><i class="bi bi-stars" style="color:#0a0a0a;"></i></div>
            <div class="ns-ai-typing-dots">
                <span></span><span></span><span></span>
            </div>
        `;
        messagesArea.appendChild(typingEl);
        scrollToBottom();
    }

    function hideTypingIndicator() {
        if (typingEl && typingEl.parentNode) {
            typingEl.parentNode.removeChild(typingEl);
        }
    }

    function scrollToBottom() {
        messagesArea.scrollTop = messagesArea.scrollHeight;
    }

    function escapeHTML(str) {
        return str.replace(/[&<>'"]/g, 
            tag => ({
                '&': '&amp;',
                '<': '&lt;',
                '>': '&gt;',
                "'": '&#39;',
                '"': '&quot;'
            }[tag])
        );
    }
}
