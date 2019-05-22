$(() => {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/TaskHub").build();
    connection.start();

    var Status = {
        Incomplete:0,
        Inprocess:1,
        Complete:2

    };

    $("#task-table").on('click','.set-inprocess', function () {
        const taskId = $(this).data("id");
        const status = "Inprocess";
        connection.invoke("UpdateAssignment", taskId, Status.Inprocess );
    });

    $("#task-table").on('click','.set-complete', function(){
        const taskId = $(this).data("id");
        const status = "Complete";
        connection.invoke("UpdateAssignment", taskId, Status.Complete );
    });

   

    connection.on("TasksUpdate", tasks => {
        console.log(tasks);
        fillTable(tasks);
    });

    const addTaskToTable = task => {
        console.log(task.id);
        $("#task-table").append(`<tr>
                                        <td>${task.name}</td>
                                        <td>`+
                                        (task.status === 0 ? `<button class="btn btn-primary set-inprocess" data-id="${task.Id}">Incomplete</button>` : `<button class="btn btn-primary set-complete" data-id="${task.id}">Being worked on by ${task.userName}</button>`)
                                            
                                        + '</td></tr>');
    }

    const fillTable = tasks => {
        $("#task-table").find("tr:gt(0)").remove();
        tasks.forEach(task => addTaskToTable(task));
    }
})