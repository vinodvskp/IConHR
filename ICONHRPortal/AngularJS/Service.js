IconApp.service('IconHRService', function ($http) {

    this.GetCountryAndCardDetails = function () {
        return $http.get("/Payment/GetCountryAndCardDetails");
    };   
  
    this.GetDeptJobRolesRpMgrDetails = function () {
        return $http.get("/Dashboard/GetDeptJobRolesRpMgrDetails");
    };

    this.AddNewEmployee = function (empName, email, phoneNumber, password, company, companySize) {
        return $http.post("/Registration/AddNewEmpDetails?empName=" + empName + "&email=" + email + "&phoneNumber=" + phoneNumber + "&password=" + password + "&company=" + company + "&companySize=" + companySize);
    };
    this.EditEmployee = function (firstName, lastName, email, phone, gender, upload, address, dob, postalCode, country) {
        var data =
        {
            firstName: firstName,
            lastName: lastName,
            email: email,
            phone: phone,
            gender: gender,
            upload: upload,
            address: address,
            dob: dob,
            postalCode: postalCode,
            country: country
        };
        return $http.post("/EditEmpProfile/EditEmployee", data);
    };
    this.UploadFiles = function (files) {
        return $http.post("/EditEmpProfile/FileUpload?file="+files);
    }
    this.PaymentAndBillingDetails =function(cardHolderName, cardType, cardNumber, CVV, cardExpMonth, cardExpYear, Name, address, country, postalCode, phoneNumber, email){
        return $http.post("/Payment/CreditCardAndBillingDetails?cardHolderName=" + cardHolderName + "&cardType=" + cardType + "&cardNumber=" + cardNumber + "&CVV=" + CVV + "&cardExpMonth=" + cardExpMonth + "&cardExpYear=" + cardExpYear +
                          "&Name=" + Name + "&address=" + address + "&country=" + country + "&postalCode=" + postalCode + "&phoneNumber=" + phoneNumber + "&email=" + email);
    }
   
    this.Login = function (email, password) {
        return $http.get("/Login/Login?email=" + email + "&password=" + password);
    };

    this.ForgotPassword = function (email) {
        return $http.get("/ForgotPassword/ForgotPassword?emailAddress=" + email);
    };

    this.ResetPassword = function (password, passwordToken) {
        return $http.get("/ResetPassword/ResetPassword?password=" + password + "&passwordToken=" + passwordToken);
    };

    this.ChangePassword = function (oldPassword, password) {
        return $http.get("/Dashboard/ChangePassword?oldPassword=" + oldPassword + "&password=" + password);
    };  

    this.getProfileImage = function (oldPassword, password) {
        return $http.get("/Dashboard/GetProfileImage");
    }; 

});