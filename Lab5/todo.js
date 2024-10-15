document.addEventListener('DOMContentLoaded', loadTasks); // Load tasks when DOM is fully loaded

function addTask() {
    const taskInput = document.getElementById('taskInput');
    const taskText = taskInput.value.trim();

    if (!taskText) {
        alert('Please enter a task!');
        return;
    }

    const taskList = document.getElementById('taskList');
    const listItem = createTaskElement(taskText);
    taskList.appendChild(listItem);

    taskInput.value = ''; // Clear input field
    saveTasks(); // Save tasks after adding
}

function createTaskElement(taskText) {
    const listItem = document.createElement('li');
    listItem.textContent = taskText;

    const removeButton = document.createElement('button');
    removeButton.textContent = 'Remove';
    removeButton.className = 'remove';
    removeButton.onclick = () => {
        listItem.remove();
        saveTasks(); // Save tasks after removing
    };

    listItem.appendChild(removeButton);
    return listItem;
}

function saveTasks() {
    const tasks = Array.from(document.querySelectorAll('#taskList li')).map(item => item.firstChild.textContent);
    localStorage.setItem('tasks', JSON.stringify(tasks));
}

function loadTasks() {
    const tasks = JSON.parse(localStorage.getItem('tasks')) || [];
    tasks.forEach(taskText => {
        const listItem = createTaskElement(taskText);
        document.getElementById('taskList').appendChild(listItem);
    });
}
