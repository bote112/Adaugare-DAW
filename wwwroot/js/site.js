document.addEventListener("DOMContentLoaded", function () {
    const deleteButtons = document.querySelectorAll('.delete-feedback');

    deleteButtons.forEach(button => {
        button.addEventListener('click', function (event) {
            event.preventDefault();
            const feedbackId = this.getAttribute('data-id');
            const confirmed = confirm('Ești sigur că vrei să ștergi acest feedback?');

            if (confirmed) {
                const form = document.createElement('form');
                form.method = 'post';
                form.action = `/Feedback/Delete/${feedbackId}`;

                const methodField = document.createElement('input');
                methodField.type = 'hidden';
                methodField.name = '_method';
                methodField.value = 'DELETE';

                const csrfField = document.createElement('input');
                csrfField.type = 'hidden';
                csrfField.name = '__RequestVerificationToken';
                csrfField.value = '@HttpContext.Current.Request.Cookies["__RequestVerificationToken"].Value'; // Acesta este un exemplu, actualizează pentru a se potrivi cu metoda ta de obținere a token-ului CSRF

                form.appendChild(methodField);
                form.appendChild(csrfField);
                document.body.appendChild(form);
                form.submit();
            }
        });
    });
});
