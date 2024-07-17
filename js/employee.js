window.onload =  function(){
    new EmployeePage();
}

class EmployeePage{
    pageTitile = "Quản lý nhân viên";
    constructor(){
        this.initEvent();
        this.loadData()
    }
    /**
     Author
     */
    initEvent(){

        try{
            //click
            document.querySelector('.btn-add').addEventListener('click', this.btnAddClick);
            //close
            const btn_close = document.querySelector('.btn-close').addEventListener('click', this.btnClose)

        }catch(error){
            console.error(error)
        }
    }

    loadData(){
        try {
            
            fetch("https://cukcuk.manhnv.net/api/v1/Employees")
            .then(res=> res.json())
            .then(data=>{
                console.log(data);
                const table = document.querySelector("#table");
                const tbody = table.querySelector("tbody")
                let i = 1;
                for(let item of data){
                    let tr = document.createElement("tr");
                    tr.innerHTML = `<td>${i}</td>
                            <td>${item.EmployeeCode}</td>
                            <td>${item.FullName}B</td>
                            <td>${item.GenderName}</td>
                            <td>${item.IdentityDate}</td>
                            <td>${item.Email}</td>
                            <td>${item.IdentityPlace}</td>`;
                            i++;
                            tbody.append(tr)
                }
            })
        } catch (error) {
            
        }
    }
    /**
     * click btn add..
     * author: Pham Nghia 9/7/2024
     */
    btnAddClick(){
       try{
        const thong_tin_nv = document.querySelector('.thong-tin-nv');
        thong_tin_nv.classList.add('open')
        thong_tin_nv.classList.remove('display-none')
        $("#maNV").focus();
       }catch(error){
        console.error(error)
       }

    }
    btnClose(){
        const thong_tin_nv = document.querySelector('.thong-tin-nv');
         thong_tin_nv.classList.remove('open');
        thong_tin_nv.classList.add('display-none');
    }
}

$(document).ready(function(){
    $('#button-save').on('click', function(e) {
        e.preventDefault();
        let maNV = $('#maNV').val()
        let hovaTen = $('#hoVaTen').val()
        let soCMTND = $('#soCMTND').val()
        let email = $('#email').val()
        let sdt  = $('#dtDiDong').val();
        let ngaySinh = $('#ngaySinh').val()
        let viTri = $('viTri').val()
        let ngayCap = $('ngayCap').val()
        let phongBan = $('phongBan').val()
        let noiCap = $('noiCap').val()
        if(ngaySinh) ngaySinh = new Date(ngaySinh)
        if(ngayCap) ngayCap = new Date(ngayCap)
        var alertString = ""
        if(maNV == null || maNV ===""){
            alertString +="Mã nhân viên không được để trống\n";
        }
        if(hovaTen == null || hovaTen ===""){
            alertString +="Họ và tên không được để trống\n";
        }
        if(soCMTND == null || soCMTND ===""){
            alertString +="Số cmtnd không được để trống\n";
        }
        if(email == null || email ===""){
            alertString +="Email không được để trống\n";
        }
        if(sdt == null || sdt ===""){
            alertString +="Số đt không được để trống\n";
        }
        if(alertString!="") {
            alert(alertString)
            return false
        }
        var employeeData = {
            createdDate: new Date().toISOString(),
            createdBy: 'string',
            modifiedDate: new Date().toISOString(),
            modifiedBy: 'string',
            employeeId: '3fa85f64-5717-4562-b3fc-2c963f66afa6',
            employeeCode: $('#maNV').val(),
            firstName: $('#hoVaTen').val().split(' ')[0],
            lastName: $('#hoVaTen').val().split(' ').slice(1).join(' '),
            fullName: $('#hoVaTen').val(),
            gender: $('input[name="gender"]:checked').val(),
            dateOfBirth: $('#ngaySinh').val(),
            phoneNumber: $('#dtDiDong').val(),
            email: $('#email').val(),
            address: $('#diaChi').val(),
            identityNumber: $('#soCMTND').val(),
            identityDate: $('#ngayCap').val(),
            identityPlace: $('#noiCap').val(),
            joinDate: new Date().toISOString(),
            martialStatus: 0,
            educationalBackground: 0,
            qualificationId: '3fa85f64-5717-4562-b3fc-2c963f66afa6',
            departmentId: '3fa85f64-5717-4562-b3fc-2c963f66afa6',
            positionId: '3fa85f64-5717-4562-b3fc-2c963f66afa6',
            nationalityId: '3fa85f64-5717-4562-b3fc-2c963f66afa6',
            workStatus: 0,
            personalTaxCode: 'string',
            salary: 0,
            positionCode: 'string',
            positionName: 'string',
            departmentCode: 'string',
            departmentName: 'string',
            qualificationName: 'string',
            nationalityName: 'string'
        };

        $.ajax({
            url: 'api/v1/Employees',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(employeeData),
            success: function(response) {
                alert('Employee data saved successfully!');
                // Additional actions like closing the form or refreshing the table can be added here
            },
            error: function(error) {
                alert('Error saving employee data.');
                console.log(error);
            }
        });
    });

    // $('#button-save').click(function(){
        

    // })

    $('input[required]').blur(function(){
       
        validate(this)
    })

    function validate (input){
        let value = $(input).val()
        if(value == null || value ===""){
            $(input).addClass('input-error')
        }else{
            $(input).removeClass('input-error')
        }
       
    }
    
})