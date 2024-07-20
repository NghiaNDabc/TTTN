window.onload = function() {
    new EmployeePage();
}

class EmployeePage {
    constructor() {
        this.pageTitle = "Quản lý nhân viên";
        this.apiUrl = 'https://cukcuk.manhnv.net/api/v1/';
        this.pageNumber = 1;
        this.pageSize = 10;
        this.initEvent();
        this.loadData(this.pageSize);
        this.loadDepart();
    }

    /**
     * Initialize events
     * Author: Pham Nghia
     */
    initEvent() {
        try {
            // Event delegation for dynamically added elements
            document.body.addEventListener('click', (event) => {
                if (event.target.closest('.btn-add')) this.btnAddClick();
                if (event.target.closest('.btn-close')) this.btnClose();
            });

            // Event for saving employee data
            document.getElementById('button-save').addEventListener('click', (e) => {
                e.preventDefault();
                this.saveEmployee();
            });

            // Event for selecting page size
            document.getElementById('pageSize').addEventListener('change', (e) => {
                this.pageSize = e.target.value;
                this.pageSizeSelected(e.target.value);
            });

            document.getElementById('next').addEventListener('click', (e)=>{
                this.pageNumber++;
                this.loadData(this.pageSize,this.pageNumber)
            })

            document.getElementById('pre').addEventListener('click', (e)=>{
                this.pageNumber--;
                this.loadData(this.pageSize,this.pageNumber)
            })
        } catch (error) {
            console.error(error);
        }
    }

    /**
     * Load employee data with the specified page size
     * Author: Pham Nghia
     * @param {Number} pageSize - Number of items to load per page
     */
    loadData(pageSize, pageNumber = 1, name = '') {
        try {
            fetch(this.apiUrl + `Employees/filter?pageSize=${pageSize}&pageNumber=${pageNumber}&name=${encodeURIComponent(name)}`)
                .then(res => res.json())
                .then(data => {
                    document.getElementById("tong").innerHTML = data["TotalPage"];
                    console.log(data);
                    const table = document.querySelector("#table");
                    const tbody = table.querySelector("tbody");
                    tbody.innerHTML = ''; // Clear existing rows
                    let i = 1;
                    data["Data"].forEach(item => {
                        let tr = document.createElement("tr");
                        tr.innerHTML = `
                            <td>${i}</td>
                            <td>${item.EmployeeCode}</td>
                            <td>${item.FullName}</td>
                            <td>${item.GenderName}</td>
                            <td>${new Date(item.IdentityDate).toLocaleDateString()}</td>
                            <td>${item.Email}</td>
                            <td>${item.IdentityPlace}</td>
                        `;
                        tbody.append(tr);
                        i++;
                    });
                })
                .catch(error => console.error('Error fetching employee data:', error));
        } catch (error) {
            console.error(error);
        }
    }
    

    /**
     * Handle page size selection change
     * Author: Pham Nghia
     * @param {Number} pageSize - Selected page size
     */
    pageSizeSelected(pageSize) {
        console.log('Selected Page Size:', pageSize);
        this.loadData(pageSize);
    }

    /**
     * Handle add button click
     * Author: Pham Nghia
     */
    btnAddClick() {
        try {
            const thong_tin_nv = document.querySelector('.thong-tin-nv');
            thong_tin_nv.classList.add('open');
            thong_tin_nv.classList.remove('display-none');
            document.getElementById("maNV").focus();

            fetch('https://cukcuk.manhnv.net/api/v1/Employees/NewEmployeeCode')
                .then(response => response.text())
                .then(data => {
                    document.getElementById("maNV").value = data;
                })
                .catch(error => console.error('Error fetching new employee code:', error));
        } catch (error) {
            console.error(error);
        }
    }

    /**
     * Handle close button click
     * Author: Pham Nghia
     */
    btnClose() {
        const thong_tin_nv = document.querySelector('.thong-tin-nv');
        thong_tin_nv.classList.remove('open');
        thong_tin_nv.classList.add('display-none');
    }

    /**
     * Save employee data
     * Author: Pham Nghia
     */
    saveEmployee() {
        const employeeData = {
            createdDate: new Date().toISOString(),
            createdBy: "Nghia",
            modifiedDate: new Date().toISOString(),
            modifiedBy: "Nghia",
            employeeId: null,//"3fa85f64-5717-4562-b3fc-2c963f66afa6", // Thay đổi hoặc thêm nếu cần thiết
            employeeCode: document.getElementById('maNV').value ,
            firstName: document.getElementById('hoVaTen').value.split(' ')[0],
            lastName: document.getElementById('hoVaTen').value.split(' ').slice(1).join(' '),
            fullName: document.getElementById('hoVaTen').value,
            gender: parseInt(document.querySelector('input[name="gender"]:checked').value, 10) || null, // Đảm bảo giá trị là số
            dateOfBirth: new Date(document.getElementById('ngaySinh').value).toISOString() || null, // Định dạng lại thành ISO
            phoneNumber: document.getElementById('dtDiDong').value || null,
            email: document.getElementById('email').value || null,
            address: document.getElementById('diaChi').value || null,
            identityNumber: document.getElementById('soCMTND').value || null,
            identityDate: new Date(document.getElementById('ngayCap').value).toISOString() || null, // Định dạng lại thành ISO
            identityPlace: document.getElementById('noiCap').value || null,
            joinDate: new Date().toISOString() ,
            martialStatus: null,//parseInt(document.querySelector('input[name="martialStatus"]:checked').value, 10), // Giá trị từ input
            educationalBackground:null,// parseInt(document.querySelector('input[name="educationalBackground"]:checked').value, 10), // Giá trị từ input
            qualificationId: null,//document.getElementById('qualificationId').value,
            departmentId: document.getElementById('phongBan').value || null,
            positionId: null,//document.getElementById('positionId').value,
            nationalityId: null,//document.getElementById('nationalityId').value,
            workStatus: null,//parseInt(document.querySelector('input[name="workStatus"]:checked').value, 10), // Giá trị từ input
            personalTaxCode:null,// document.getElementById('personalTaxCode').value,
            salary: null,//parseFloat(document.getElementById('salary').value), // Đảm bảo giá trị là số
            positionCode: null,//document.getElementById('positionCode').value,
            positionName: null,//document.getElementById('positionName').value,
            departmentCode: null,//document.getElementById('departmentCode').value,
            departmentName:null,// document.getElementById('departmentName').value,
            qualificationName:null,// document.getElementById('qualificationName').value,
            nationalityName: null,//document.getElementById('nationalityName').value
        };
        

        const validationError = this.validateEmployeeData(employeeData);
        if (validationError) {
            alert(validationError);
            return;
        }

        fetch(this.apiUrl + 'Employees', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(employeeData)
        })
        .then(response => {
            if (response.ok) {
                alert('Thành công!');
                this.loadData(document.getElementById('pageSize').value);
                this.btnClose();
            } 
            // else {
            //     throw new Error('Failed to save employee');
            // }
        })
        .catch(error => {
            alert('Lỗi thêm nv. ' + error);
           
        });
    }

    loadDepart(){
        const apiUrl = 'https://cukcuk.manhnv.net/api/v1/Departments';

      // Gọi API
      fetch(apiUrl)
        .then(response => response.json())
        .then(data => {
          const selectElement = document.getElementById('phongBan');
          
          // Duyệt qua dữ liệu và tạo các thẻ <option>
          data.forEach(item => {
            const option = document.createElement('option');
            option.value = item.DepartmentId;
            option.text = item.DepartmentName;
            selectElement.appendChild(option);
          });
        })
        .catch(error => console.error('Error fetching data:', error));
    }

    /**
     * Validate employee data
     * Author: Pham Nghia
     */
    validateEmployeeData(employeeData) {
        let alertString = "";
        if (!employeeData.employeeCode) {
            alertString += "Mã nhân viên không được để trống\n";
        }
        if (!employeeData.fullName) {
            alertString += "Họ và tên không được để trống\n";
        }
        if (!employeeData.identityNumber) {
            alertString += "Số cmtnd không được để trống\n";
        }
        if (!employeeData.email) {
            alertString += "Email không được để trống\n";
        }
        if (!employeeData.phoneNumber) {
            alertString += "Số đt không được để trống\n";
        }
        return alertString || null;
    }
}
