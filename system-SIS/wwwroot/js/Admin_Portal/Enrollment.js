// Function to select/deselect all checkboxes
function selectAllCheckboxes(source) {
    const checkboxes = document.querySelectorAll('.studentCheckbox');
    checkboxes.forEach(checkbox => checkbox.checked = source.checked);
}