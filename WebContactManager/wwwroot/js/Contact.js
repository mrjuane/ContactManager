
var table;
let ENTITY_SAVE;// = "/Contact/Insert";
let ENTITY_UPDATE;// = "/Contact/Update";
let ENTITY_DELETE;// = "/Contact/Delete";
let GET_ALL_ENTITIES;// = "/Contact/GetAllContacts";

$(document).ready(function () {

    try {
        table = $('#table_id').DataTable({
            ajax: { url: GET_ALL_ENTITIES, dataSrc: "" },
            columns:[ 
                { data: "constactId" },
                { data: "firstName" },
                { data: "lastName" },
                { data: "address" },
                { data: "email" },
                { data: "phone" },
                { data: "genre" }
            ],
           columnDefs: [
               {
                   targets: 7,
                   render: function (data, type, row, meta) {
                       return `
                                <div class='input-group'>
                                      <input type="button" class="btn btn-warning btn-sm edit text-white" id=${meta.row} value="Edit"/>
                                      <input type="button" class="btn btn-danger btn-sm delete text-white" id = ${meta.row} value = "Delete" />
                                      <input type="button" class="btn btn-info btn-sm Tasks text-white" id = ${meta.row} value = "Tasks" />
                                <div/>
                            `;
                   }
               }
           ]
        });
    } catch (e) {
        console.log(e);
    }
});

$(document).ready(() => {
    $('#table_id tbody').on('click', '.edit', function () {

        var id = $(this).attr('id').match(/\d+/)[0];

        let data = $('#table_id').DataTable().row(id).data();

        $("#ModalForm").show();
        DataToEdit(data);
    });
});

$(document).ready(() => {
    $('#table_id tbody').on('click', '.delete', function () {

        var id = $(this).attr('id').match(/\d+/)[0];

        let data = $('#table_id').DataTable().row(id).data();

        let confirmDelete = confirm(`Would you want to Delete the Contact : ${data.firstName + ' ' + data.lastName} `);

        if (confirmDelete) {
            Delete(data.constactId);
        }
    });
});

$(document).ready(() => {
    $("#save").click((e) => {
        e.preventDefault();

        if (Validations() === false) return;

        let confirmbool = confirm("Do you want to Save?");

        if (confirmbool) {
            InsertUpdate();
        }
    });
});

$(document).ready(() => {
    $("#addnewitem").click(() => {
        $("#ModalForm").show();
        CleanControls();
    });

});

$(document).ready(() => {
    $(".cancel").click(() => {

        let confirmbool = confirm("Do you want to Cancel?");
        if (confirmbool) {
            CleanControls();
            $("#ModalForm").hide();
        }
    });
});

$(document).ready(() => {
    $("#Genre").change(() => {
        $(this).attr('option:selected');        
    });
});

//Insert Update data
const InsertUpdate = () => {

    try {

        let id = $('#ConstactId').val() === "" ? 0 : $('#ConstactId').val() ;

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

//set data to entity
const SetData = () => {

    return {
        ConstactId: $('#ConstactId').val() === "" ? 0 : $('#ConstactId').val(),
        FirstName: $('#FirstName').val(),
        LastName: $('#LastName').val(),
        Address: $('#Address').val(),
        Email: $('#Email').val(),
        Phone: $('#Phone').val(),
        Genre: $('#Genre :selected').val()
    };

}

//load fields to Update
const DataToEdit = (data) => {

        $('#ConstactId').val(data.constactId);
        $('#FirstName').val(data.firstName);
        $('#LastName').val(data.lastName);
        $('#Address').val(data.address);
        $('#Email').val(data.email);
        $('#Phone').val(data.phone);
        $('#Genre').val(data.genre);     
}

//delete entity
const Delete = (contactId) => {

    try {    
        if (contactId > 0) {
            $.ajax({
                url: ENTITY_DELETE,
                type: 'DELETE',
                dataType: 'JSON',
                data: {id:contactId},
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

const CleanControls = () => {
    $('#frmdatos').trigger('reset');
}

//to validate the form
const Validations = () => {
    if (!$('#frmdatos').valid()) {
        return false;
    }

}