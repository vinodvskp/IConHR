(function () {
    "use strict";
    angular.module("IconHRModule")
        .constant("apiUrl", "http://localhost:51704/api/")

        .factory("iconHrService", iconHrService);
    iconHrService.$inject = ["$resource", "apiUrl", "$rootScope"];

    function iconHrService($resource, apiUrl, $rootScope) {
        return {
            invokeService: function (token) { // TODO token need to be change parameter
                return $resource(apiUrl, null, {

                    getCountryAndCardDetails: {
                        //return $http.get("/Payment/GetCountryAndCardDetails");
                        method: "Get", isArray: false, url: apiUrl + "PaymentApi/CountryCardDetails", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    
                  
                    getEmployees: {
                        method: "Get", isArray: true, url: apiUrl + "employeeApi/get", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getEmployeeDetail: {
                        method: "Get", isArray: false, url: apiUrl + "employeeapi/get?id=0", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },

                    getDeptJobRolesRpMgrDetails: {
                        //return $http.get("/Dashboard/GetDeptJobRolesRpMgrDetails");
                        method: "Get", isArray: false, url: apiUrl + "/Dashboard/GetDeptJobRolesRpMgrDetails", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },

                    addNewEmployee: {
                       
                        //return $http.post("/Registration/AddNewEmpDetails?empName=" + empName + "&email=" + email + "&phoneNumber=" + phoneNumber + "&password=" + password + "&company=" + company + "&companySize=" + companySize);
                        method: "Post", isArray: false, url: apiUrl + "employeeapi/Post", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },

                    editEmployee: {
                        //return $http.post("/EditEmpProfile/EditEmployee", data);
                        method: "Put", isArray: false, url: apiUrl + "employeeapi/Put", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },

                    savePaymentAndBillingDetails: {
                        // return $http.post("/Payment/CreditCardAndBillingDetails");
                        method: "Post", isArray: true, url: apiUrl + "PaymentApi/Post", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },

                    forgotPassword: {
                        // return $http.get("/ForgotPassword/ForgotPassword?emailAddress=" + email);
                        method: "Post", isArray: false, url: apiUrl + "userapi/ForgotPassword", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },

                    resetPassword: {
                        // return $http.get("/ResetPassword/ResetPassword?password=" + password + "&passwordToken=" + passwordToken);
                        method: "POST", isArray: false, url: apiUrl + "userApi/ResetPassword", headers: {
                            "Authorization": 'bearer' + ' ' + '8UFe4RD8j33NhcEIDQjZY4FDhBGqaroHh4I9X8Dz3EHUA-M64ENXWSjCId4gZg9nyKFcOSWF9-VfgwUo5qTCakVX2Z1c4m7IK-U91eVbu-q4hUwkDSD8q9HIkJovJzxB3W2aX13WzRgQn3jiXLuLLcoDtWvmd-TE1rIPLHuil5lBxtIgbZN6JZfKPwz6WpCBYuxJm57fSFmUIHpWdTe2-_FIliJqEsbVnE0_tM3Be4VziTM-Jpbzf386enV73nyTSagWYdVnFYLjS5404WfrjbG8qefvqzssS6uyG9_vOCcNrOv18XGNa5zbUPezb5sogeLNp0CVv3rZhFCD8P0O3dxOMSbCs5xiwQDZ1M-pRaykxAWhlRf5xvlXHAXRbZGufY5xuYrErGgYWLfhLoKtYpEJ4j0XaxhaVyuBKTiYE_A7lhlNQK5Tl2oS1DHBZB8l'}
                    },

                    changePassword: {
                        method: "Post", isArray: false, url: apiUrl + "changepasswordapi/post", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                        //return $http.get("/Dashboard/ChangePassword?oldPassword=" + oldPassword + "&password=" + password);
                    },


                    getProfileImage: {
                        //return $http.get("/Dashboard/GetProfileImage");
                        method: "Get", isArray: true, url: apiUrl + "userapi/GetProfilePhoto", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getCountries: {
                        method: "Get", isArray: true, url: apiUrl + "countryApi/get", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getLocations: {
                        method: "Get", isArray: true, url: apiUrl + "locationApi/locationNames", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getHolidayAbsenceSetting: {
                        method: "Get", isArray: false, url: apiUrl + "HolidaysAbsenceSettingApi/Get?id=0", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    saveHolidayAbsenceSetting: {
                        method: "Post", isArray: true, url: apiUrl + "HolidaysAbsenceSettingApi/Post", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },

                    //EmployeeSetting API
                    getEmployeeSetting: {
                        method: "Get", isArray: false, url: apiUrl + "EmployeeSettingApi/get?id=0", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    saveEmployeeSetting: {
                        method: "Post", isArray: true, url: apiUrl + "EmployeeSettingApi/Post", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },

                    //EmailSetting API
                    getEmailSetting: {
                        method: "Get", isArray: false, url: apiUrl + "EmailSettingApi/get?id=0", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    saveEmailSetting: {
                        method: "Post", isArray: true, url: apiUrl + "EmailSettingApi/Post", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    updateHolidayAbsenceSetting: {
                        method: "Put", isArray: true, url: apiUrl + "HolidaysAbsenceSettingApi/Put", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getAllCompanySettingInformation: {
                        method: "Get", isArray: true, url: apiUrl + "CompanySettingApi/Get", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    saveCompanySettings: {
                        method: "Post", isArray: false, url: apiUrl + "CompanySettingApi/Post", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    SaveLocations: {
                        method: "Post", isArray: false, url: apiUrl + "locationApi/Post", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    SaveWorkPattern: {
                        method: "Post", isArray: false, url: apiUrl + "workpatternApi/Post", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    SaveDepartment: {
                        method: "Post", isArray: false, url: apiUrl + "departmentapi/Post", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getLocationsNames: {
                        method: "Get", isArray: true, url: apiUrl + "locationApi/locationNames", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getDepartmentNames: {
                        method: "Get", isArray: true, url: apiUrl + "departmentapi/departmentNames", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getWorkPatternOptions: {
                        method: "Get", isArray: true, url: apiUrl + "workpatternApi/workPatternsOptions", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getCompanyById: {
                        method: "Get", isArray: false, url: apiUrl + "CompanySettingApi/Get?id=0", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getAdminSettings: {
                        method: "Get", isArray: true, url: apiUrl + "AdministratorSettingApi/Get?id=0", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getAdminManagerNames: {
                        method: "Get", isArray: true, url: apiUrl + "AdministratorSettingApi/AdminMangerNames", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    SaveAdminSetting: {
                        method: "Post", isArray: false, url: apiUrl + "AdministratorSettingApi/Post", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    UpdateAdminSetting: {
                        method: "Put", isArray: false, url: apiUrl + "AdministratorSettingApi/Put", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getEmployeeOptions: {
                        method: "Get", isArray: true, url: apiUrl + "EmployeeApi/employeeNames", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    saveBulkUploadEmployees: {
                        method: "Post", isArray: false, url: apiUrl + "EmployeeApi/EmployeeBulkInsert", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getDocumentTypeOptions: {
                        method: "Get", isArray: true, url: apiUrl + "documentapi/DocumentType", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getPlannerTypeOptions: {
                        method: "Get", isArray: true, url: apiUrl + "plannerapi/PlannerTypes", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getDocuments: {
                        method: "Get", isArray: true, url: apiUrl + "documentapi/Get", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    }, 
                    getDocumentsById: {
                        method: "Get", isArray: true, url: apiUrl + "documentapi/Get", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    }, 
                    getPlanners: {
                        method: "Get", isArray: true, url: apiUrl + "plannerapi/Get", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getPlannersByFilters: {
                        method: "Post", isArray: true, url: apiUrl + "plannerapi/searchFilters", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getPlannerFilter: {
                        method: "Get", isArray: false, url: apiUrl + "plannerapi/PlannerFilter", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    saveDocuments: {
                        method: "Post", isArray: false, url: apiUrl + "documentapi/Post", headers: {"Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    DeleteDocument: {
                        method: "Delete", isArray: false, url: apiUrl + "documentapi/Delete", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    updateDocuments: {
                        method: "Put", isArray: false, url: apiUrl + "documentapi/Put", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    savePlanner: {
                        method: "Post", isArray: false, url: apiUrl + "plannerapi/Post", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    updatePlanner: {
                        method: "Put", isArray: false, url: apiUrl + "plannerapi/Put", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    deletePlanner: {
                        method: "Delete", isArray: false, url: apiUrl + "plannerapi/Delete", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },

                     addTimeSheet: {
                        method: "Post", isArray: false, url: apiUrl + "EmployeeTimesheetApi/Post", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getTimeSheets: {
                        method: "Get", isArray: true, url: apiUrl + "EmployeeTimesheetApi/Get", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getTimeSheetsByRptMng: {
                        method: "Get", isArray: true, url: apiUrl + "EmployeeTimesheetApi/GetTimeSheetsByRptMng", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    addEmployeeLogBook: {
                        method: "Post", isArray: false, url: apiUrl + "EmployeeLogBookApi/Post", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getEmployeeLogBook: {
                        method: "Get", isArray: true, url: apiUrl + "EmployeeLogBookApi/Get", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getEmployeeLogBookById: {
                        method: "Get", isArray: false, url: apiUrl + "EmployeeLogBookApi/GetById", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getAdminDetails: {
                        method: "Get", isArray: true, url: apiUrl + "EmployeeApi/GetAdminDetails", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    deleteLogbook: {
                        method: "Delete", isArray: false, url: apiUrl + "EmployeeLogBookApi/Delete", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getReviewSettings: {
                        method: "Get", isArray: true, url: apiUrl + "PerformanceReviewSettingApi/Get", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getReviewSettingsById: {
                        method: "Get", isArray: false, url: apiUrl + "PerformanceReviewSettingApi/Get", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    saveReviewSettings: {
                        method: "Post", isArray: false, url: apiUrl + "PerformanceReviewSettingApi/Post", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    updateReviewSettings: {
                        method: "Put", isArray: false, url: apiUrl + "PerformanceReviewSettingApi/Put", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    deleteReviewSettings: {
                        method: "Delete", isArray: false, url: apiUrl + "PerformanceReviewSettingApi/Delete", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getJobRolesOption: {
                        method: "Get", isArray: true, url: apiUrl + "PerformanceReviewSettingApi/JobRoles", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getEmployementTypes: {
                        method: "Get", isArray: true, url: apiUrl + "PerformanceReviewSettingApi/EmployementTypes", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getNotificaitons: {
                        method: "Get", isArray: true, url: apiUrl + "employeeApi/GetNotificaitons", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    updateNotificaitonStatus: {
                        method: "POST", isArray: false, url: apiUrl + "employeeApi/updateNotificaitonStatus", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getPerformanceSegment: {
                        method: "Get", isArray: true, url: apiUrl + "PerformanceSegmentApi/Get", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getRatings: {
                        method: "Get", isArray: true, url: apiUrl + "PerformanceSegmentApi/Ratings", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    saveEmployeePerformance: {
                        method: "Post", isArray: false, url: apiUrl + "EmployeePerformanceApi/Post", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getReviewNames: {
                        method: "Get", isArray: true, url: apiUrl + "PerformanceReviewSettingApi/ReviewNames", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getManagerPerformanceById: {
                        method: "Get", isArray: true, url: apiUrl + "ManagerPerformanceApi/Get", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getSPManagerPerformanceByReviewId: {
                        method: "Get", isArray: false, url: apiUrl + "ManagerPerformanceApi/Sp_MgrPerformanceDetails", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    saveManagerPerformance: {
                        method: "Post", isArray: false, url: apiUrl + "ManagerPerformanceApi/Post", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getEmployeePerformanceById: {
                        method: "Get", isArray: true, url: apiUrl + "EmployeePerformanceApi/Get", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getSPEmployeePerformanceByEmpMgrReviewId: {
                        method: "Get", isArray: false, url: apiUrl + "EmployeePerformanceApi/Sp_EmpMgrPerformanceDetails", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    saveRule: {
                        method: "Post", isArray: false, url: apiUrl + "AuthorisationRuleSettingApi/Post", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getAuthorisationRuleDetails: {
                        method: "Get", isArray: true, url: apiUrl + "AuthorisationRuleSettingApi/GetAuthorisationRuleDetails", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getEmployeeScoreDetails: {
                        method: "Get", isArray: false, url: apiUrl + "EmployeePerformanceApi/GetEmployeeScoreDetails", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    },
                    getEmployee: {
                        method: "Get", isArray: false, url: apiUrl + "employeeApi/GetEmployee", headers: { "Authorization": 'bearer' + ' ' + sessionStorage["accessToken"] }
                    }
                });
            }
        };
    }
})();