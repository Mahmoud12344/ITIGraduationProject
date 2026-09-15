document.addEventListener('DOMContentLoaded', function () {
    const inputEl = document.getElementById('fs-ai-input');
    const sendBtn = document.getElementById('fs-ai-send-btn');
    const messagesArea = document.getElementById('fs-ai-messages-area');
    const resetBtn = document.getElementById('fs-ai-reset-btn');
    const modelSelect = document.getElementById('fs-ai-model-select');
    const modelLabel = document.getElementById('fs-ai-model-label');
    const modelOptions = document.querySelectorAll('.fs-model-option');
    const suggestionBtns = document.querySelectorAll('.fs-ai-suggestion-pill');
    
    // Load History
    fetch('/api/aichat/history')
        .then(res => res.json())
        .then(data => {
            if (data && data.length > 0) {
                // Clear welcome message and suggestions if there is history
                const welcomeMsg = document.querySelector('.ns-ai-welcome');
                if (welcomeMsg) welcomeMsg.style.display = 'none';
                
                const suggContainer = document.getElementById('fs-ai-suggestions');
                if (suggContainer) suggContainer.style.display = 'none';

                data.forEach(msg => {
                    if (msg.role === 'user') {
                        addUserMessageUI(msg.content);
                    } else if (msg.role === 'assistant') {
                        addAIMessageUI(msg.content);
                    }
                });
            }
        })
        .catch(err => console.error('Failed to load chat history', err));

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
            }[tag] || tag)
        );
    }

    function addUserMessageUI(text) {
        const html = `
            <div class="ns-ai-bubble-user ns-animate-fadeIn" style="align-self: flex-end; max-width: 85%;">
                <div class="ns-ai-bubble-content shadow-sm" style="background: linear-gradient(135deg, rgba(251,191,36,0.2), rgba(245,158,11,0.15)); border: 1px solid rgba(251,191,36,0.3); border-radius: 1rem 1rem 0 1rem; padding: 1rem; color: var(--ns-text); line-height: 1.5; font-size: 0.875rem;">
                    ${escapeHTML(text)}
                </div>
            </div>
        `;
        messagesArea.insertAdjacentHTML('beforeend', html);
        scrollToBottom();
    }

    function addAIMessageUI(text) {
        let htmlContent = '';
        if (window.marked && window.DOMPurify) {
            htmlContent = DOMPurify.sanitize(marked.parse(text));
        } else {
            htmlContent = escapeHTML(text);
        }

        const html = `
            <div class="ns-ai-bubble-ai ns-animate-fadeIn d-flex gap-3" style="align-self: flex-start; max-width: 85%;">
                <div class="ns-ai-avatar flex-shrink-0 mt-1 d-flex align-items-center justify-content-center" style="width: 2rem; height: 2rem; border-radius: 0.5rem; background: linear-gradient(135deg, #fbbf24, #f59e0b);">
                    <i class="bi bi-stars text-dark" style="font-size: 1rem;"></i>
                </div>
                <div class="ns-ai-bubble-content shadow-sm w-100" style="background-color: var(--ns-bg-card); border: 1px solid var(--ns-border-light); border-radius: 1rem 1rem 1rem 0; padding: 1rem; color: var(--ns-text); line-height: 1.6; font-size: 0.875rem;">
                    ${htmlContent}
                </div>
            </div>
        `;
        messagesArea.insertAdjacentHTML('beforeend', html);
        scrollToBottom();
    }
    
    let typingEl = null;
    function showTypingIndicator() {
        const html = `
            <div class="ns-ai-typing ns-animate-fadeIn d-flex gap-3" id="fs-ai-typing-indicator" style="align-self: flex-start;">
                <div class="ns-ai-avatar flex-shrink-0 mt-1 d-flex align-items-center justify-content-center" style="width: 2rem; height: 2rem; border-radius: 0.5rem; background: linear-gradient(135deg, #fbbf24, #f59e0b);">
                    <i class="bi bi-stars text-dark" style="font-size: 1rem;"></i>
                </div>
                <div class="ns-ai-typing-dots d-flex gap-2 align-items-center" style="background-color: var(--ns-bg-card); border: 1px solid var(--ns-border-light); border-radius: 1rem 1rem 1rem 0; padding: 1rem;">
                    <span style="width: 8px; height: 8px; border-radius: 50%; background-color: var(--ns-text-muted); animation: ns-ai-dot-bounce 1.4s infinite ease-in-out both; animation-delay: -0.32s;"></span>
                    <span style="width: 8px; height: 8px; border-radius: 50%; background-color: var(--ns-text-muted); animation: ns-ai-dot-bounce 1.4s infinite ease-in-out both; animation-delay: -0.16s;"></span>
                    <span style="width: 8px; height: 8px; border-radius: 50%; background-color: var(--ns-text-muted); animation: ns-ai-dot-bounce 1.4s infinite ease-in-out both;"></span>
                </div>
            </div>
        `;
        messagesArea.insertAdjacentHTML('beforeend', html);
        typingEl = document.getElementById('fs-ai-typing-indicator');
        scrollToBottom();
    }

    function hideTypingIndicator() {
        if (typingEl) {
            typingEl.remove();
            typingEl = null;
        }
    }

    function sendMessage(text) {
        if (!text || text.trim() === '') return;
        
        // Hide welcome & suggestions
        const welcomeMsg = document.querySelector('.ns-ai-welcome');
        if (welcomeMsg) welcomeMsg.style.display = 'none';
        
        const suggContainer = document.getElementById('fs-ai-suggestions');
        if (suggContainer) suggContainer.style.display = 'none';

        addUserMessageUI(text);
        inputEl.value = '';
        inputEl.disabled = true;
        sendBtn.disabled = true;
        
        showTypingIndicator();
        
        const selectedModel = modelSelect ? modelSelect.value : "";

        fetch('/api/aichat/ask', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ message: text, model: selectedModel })
        })
        .then(res => res.json())
        .then(data => {
            hideTypingIndicator();
            inputEl.disabled = false;
            sendBtn.disabled = false;
            inputEl.focus();
            
            addAIMessageUI(data.response);
        })
        .catch(err => {
            console.error('AI Chat Error:', err);
            hideTypingIndicator();
            inputEl.disabled = false;
            sendBtn.disabled = false;
            inputEl.focus();
            addAIMessageUI("I'm sorry, I'm having trouble connecting right now. Please try again later.");
        });
    }

    sendBtn.addEventListener('click', () => sendMessage(inputEl.value));
    
    inputEl.addEventListener('keypress', (e) => {
        if (e.key === 'Enter') {
            sendMessage(inputEl.value);
        }
    });

    suggestionBtns.forEach(btn => {
        btn.addEventListener('click', () => {
            sendMessage(btn.textContent);
        });
    });

    // Model Selector Logic
    modelOptions.forEach(option => {
        option.addEventListener('click', function(e) {
            e.preventDefault();
            
            // Remove active class from all
            modelOptions.forEach(opt => opt.classList.remove('active'));
            // Add active class to clicked
            this.classList.add('active');
            
            // Update hidden input value
            modelSelect.value = this.getAttribute('data-model');
            
            // Update button label (extracting just the name, removing "(Fallback)" if present to save space)
            let text = this.innerText;
            if (text.includes('(')) {
                text = text.split('(')[0].trim();
            }
            modelLabel.innerText = text;
        });
    });

    resetBtn.addEventListener('click', () => {
        if (confirm('Clear chat history?')) {
            // Keep welcome msg
            const welcomeMsg = document.querySelector('.ns-ai-welcome');
            const suggContainer = document.getElementById('fs-ai-suggestions');
            
            messagesArea.innerHTML = '';
            
            if (welcomeMsg) {
                welcomeMsg.style.display = 'block';
                messagesArea.appendChild(welcomeMsg);
            }
            if (suggContainer) {
                suggContainer.style.display = 'flex';
                messagesArea.appendChild(suggContainer);
            }
            
            // Note: History is still on the backend, a real reset would require an API call to clear backend history.
        }
    });
});
