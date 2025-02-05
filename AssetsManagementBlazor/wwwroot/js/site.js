window.bootstrapModal = (id) => {
    setTimeout(() => {
        var modalElement = document.getElementById(id);
        if (modalElement) {
            var modal = new bootstrap.Modal(modalElement, { backdrop: 'static', keyboard: false });
            modal.show();
        } else {
            console.error("Modal element not found: " + id);
        }
    }, 100); // Delay to allow DOM rendering
};
