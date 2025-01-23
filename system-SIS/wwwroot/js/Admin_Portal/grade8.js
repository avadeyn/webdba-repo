// Select the buttons by their IDs
const editBtn = document.getElementById('editBtn');
const deleteBtn = document.getElementById('deleteBtn');

// Add event listeners to the buttons to stop event propagation
if (editBtn) {
    editBtn.addEventListener('click', function (event) {
        event.stopPropagation(); // Prevent row click from being triggered
    });
}

if (deleteBtn) {
    deleteBtn.addEventListener('click', function (event) {
        event.stopPropagation(); // Prevent row click from being triggered
    });
}