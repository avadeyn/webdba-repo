// Function to select/deselect all checkboxes
function selectAllCheckboxes(source) {
    const checkboxes = document.querySelectorAll('.studentCheckbox');
    checkboxes.forEach(checkbox => checkbox.checked = source.checked);
}

const deleteBtn = document.getElementById('deleteBtn');
if (deleteBtn) {
    deleteBtn.addEventListener('click', function (event) {
        event.stopPropagation(); // Prevent row click from being triggered
    });
}