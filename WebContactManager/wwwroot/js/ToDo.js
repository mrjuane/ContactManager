var ToDoTable;
let ENTITY_SAVE;
let ENTITY_UPDATE;
let ENTITY_DELETE;
let GET_ALL_ENTITIES;

$(document).ready(() => {

    //$('#dtToDo').DataTable({
        
    //});

});

$(document).ready(() => {
    $('.showmodal').click(() => {
        $('#todoModal').show();
    });

    $('.canceltodo').click(() => {
        $('#todoModal').hide();
    });
});


//set data to entity
const SetToDoData = () => {

    return { ToDoId: $('#ToDoId').val() === "" ? 0 : $('#ToDoId').val(),
             ContactId: $('#ContactId').val(),
             Task: $('#Task').val(),
             Description: $('#Description').val(),
             IsCompleted: $('#IsCompleted').val()
    };

}

//Insert Update data
const InsertUpdate = () => {

    try {

        let id = $('#ToDoId').val() === "" ? 0 : $('#ToDoId').val();

        let urlstr = '';

        if (id === 0) {
            urlstr = ENTITY_SAVE;
        } else {
            urlstr = ENTITY_UPDATE;
        }
        var contact = SetData();

        $.post(urlstr, contact)
            .done((data) => {
                if (data > 0) {
                    CleanControls();
                    $("#ModalForm").hide();
                    alert('Success..');
                    //reload grid///
                    table.ajax.reload();
                }
            }).fail((error) => {
                alert(error.responseText);
            });

    } catch (e) {
        console.log(e);
    }
}

//load fields to Update
const DataToEdit = (data) => {
    $('#ToDoId').val(data.ToDoId);
    $('#ContactId').val(data.ContactId);
    $('#Task').val(data.Task);
    $('#Description').val(data.Description);
    $('#IsCompleted').val(data.IsCompleted);
}

//delete entity
const Delete = (contactId) => {

    try {
        if (contactId > 0) {
            $.ajax({
                url: ENTITY_DELETE,
                type: 'DELETE',
                dataType: 'JSON',
                data: { id: contactId },
                success: (data) => {
                    alert('Success..');
                    //reload grid///
                    table.ajax.reload();
                },
                error: (err) => {
                    console.log(err);
                }
            });
        }
    } catch (e) {
        console.log(e);
    }

}
