// Fetch Employees
async function fetchEmployees() {
    const response = await fetch('https://localhost:5001/api/employees'); // Use your API endpoint
    const employees = await response.json();
    displayEmployees(employees);
}

function displayEmployees(employees) {
    const employeeList = document.getElementById('employee-ul');
    employeeList.innerHTML = ""; // Clear the list before displaying new data

    employees.forEach(employee => {
        const li = document.createElement('li');
        li.innerHTML = `Employee No: ${employee.empNo}, Name: ${employee.empName}, Salary: $${employee.salaryAmount}`;
        employeeList.appendChild(li);
    });
}
