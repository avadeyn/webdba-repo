// Validate Grade Input and Recalculate Final Grade
function validateGrade(input) {
    const value = input.value;

    // Allow only two-digit or three-digit integers (65-100)
    if (!/^\d{1,3}$/.test(value) || parseInt(value) > 100 || parseInt(value) < 65) {
        input.classList.add("is-invalid");
    } else {
        input.classList.remove("is-invalid");
    }

    // Recalculate the final grade for the row
    recalculateFinalGrade(input.closest("tr"));
}

// Function to recalculate final grade and remark
function recalculateFinalGrade(row) {
    const gradeInputs = row.querySelectorAll("input[data-grade]");
    let total = 0;
    let count = 0;

    // Check if each quarter's input is valid and not empty
    let isValid = true;
    gradeInputs.forEach((input, index) => {
        const value = parseInt(input.value, 10);
        if (!isNaN(value)) {
            total += value;
            count++;
        } else if (input.value === "") {
            // If a grade is missing, disable the next quarter input
            disableNextQuarters(gradeInputs, index);
        }
    });

    // Calculate the final grade (sum of all grades divided by 4)
    const finalGrade = count === 4 ? (total / 4).toFixed(2) : "-";
    const finalGradeCell = row.querySelector(".final-grade");
    const remarkCell = row.querySelector(".remark");

    // Update Final Grade Cell
    finalGradeCell.textContent = finalGrade !== "-" ? finalGrade : "-";

    // Update Remark Cell
    if (finalGrade !== "-" && finalGrade >= 75) {
        remarkCell.textContent = "Passed";
        remarkCell.style.color = "green";
    } else if (finalGrade !== "-" && finalGrade < 75) {
        remarkCell.textContent = "Failed";
        remarkCell.style.color = "red";
    } else {
        remarkCell.textContent = "-";
        remarkCell.style.color = "black";
    }
}

