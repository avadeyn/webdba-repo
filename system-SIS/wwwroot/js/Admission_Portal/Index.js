document.addEventListener("DOMContentLoaded", function () {
    // Validate LRN for exactly 12 digits and only integers
    document.getElementById("lrn").addEventListener("input", function () {
        const lrnField = this;
        const lrnValue = lrnField.value;

        // Only allow numbers and ensure the value has exactly 12 digits
        if (/^\d{12}$/.test(lrnValue)) {
            lrnField.setCustomValidity("");  // Valid input, no error
        } else {
            lrnField.setCustomValidity("LRN must be exactly 12 digits and only integers.");  // Invalid input, error message
        }
    });
});s