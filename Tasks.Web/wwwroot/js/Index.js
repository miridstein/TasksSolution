$(() => {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/TaskHub").build();
    console.log("hello");
    connection.start();

    var Status = {
        Incomplete:0,
        Inprocess:1,
        Complete:2

    };

    $(".set-inprocess").on('click', () => {
        const taskId = $(this).data("id");
        const status = "Inprocess";
        connection.invoke("UpdateAssignment", { taskId, Status:Status.Inprocess });
    });

    $(".set-complete").on('click', function(){
        const taskId = $(this).data("id");
        const status = "Complete";
        connection.invoke("UpdateAssignment", { taskId, Status:Status.Complete });
        console.log(Status.Complete);
    });

    connection.on("TasksUpdate", tasks => {
        $("#messages").append(`<h4>${chatMessage.name} says: ${chatMessage.message}</h4>`)
        fillTable(tasks);
    });

    const addTaskToTable = task => {
        $("#task-table").append(`<tr>
                                        <td>${task.Name}</td>
                                        <td>${task.Status}</td><td>`+
                                        (task.Status = Incomplete ? `<button class="btn btn-primary set-inprocess" data-id="${task.Id}">Incomplete</button>` : `<button class="btn btn-primary set-complete" data-id="${task.Id}">Being worked on by ${task.UserName}</button>`)
                                            
                                        + '</td></tr>');
    }

    const fillTable = tasks => {
        $("#task-table").find("tr:gt(0)").remove();
        tasks.forEach(task => addTaskToTable(task));
    }
})