jQuery(document).ready(function () {
   // $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
    if (jQuery('#calendar').fullCalendar != null || jQuery('#calendar').fullCalendar != undefined)
        jQuery('#calendar').fullCalendar('render');
    // $('#calendar1').fullCalendar('render');
    //});
    // $('#myTab a:first').tab('show');
});





(function () {

    'use strict';

    angular.module('IconHRModule')
        .controller('plannerController', plannerController);

    plannerController.$inject = ['$scope', '$rootScope', '$window', 'iconHrService', 'helper'];

    function plannerController($scope, $rootScope, $window, iconHrService, helper) {

        $scope.modalShown = false;
        $scope.Message = 'Saved Successfully';
        $scope.selectedPlannerType = { id: -1, test: 'Select Type' };

        $scope.employee = [];
        $scope.department = [];
        $scope.officeLocation = [];
        $scope.selectedLocations = [];
        $scope.selectedDepartments = [];
        $scope.selectedEmployees = [];
        $scope.showFilter = false;

        $scope.users = [
            { "id": 1, "name": "Ali" },
            { "id": 2, "name": "Sara" },
            { "id": 3, "name": "Babak" },
            { "id": 4, "name": "Sanaz" },
            { "id": 5, "name": "Dariush" },
        ];

        $scope.selectedUserIds = [3, 5];

        $scope.planner = {
            PlannedEventName: '',
            PlannerCategoryID: null,
            PlannedDate: null,
        };
        var eventSource = [];
        var eventSource1 = [
            {
                title: 'My Event',
                start: new Date(),
                description: 'This is a cool event',
                color: '#5f6dd0'
            },
            {
                title: 'My Event',
                start: new moment().add(1, 'days'),
                description: 'This is a cool event',
                color: '#af6dd0'
            }
        ];
        onInit();

        function onInit() {
            jQuery('#calendar').fullCalendar('rerenderEvents', eventSource1);
            jQuery(".fc-month-button").click();
            jQuery(".fc-month-button").trigger('click');
            iconHrService.invokeService().getPlannerTypeOptions().$promise.then(function (response) {
                $scope.plannerTypes = response;
                $scope.plannerTypes.push({ id: -1, text: 'Select Type' });
            });
            var employeeId = 0;
            var fromScreen = angular.element.find('#hdnScreenName')[0].value;

            if (fromScreen == "planner") {
                $scope.showFilter = true;
            }

            if (fromScreen == 'employeeScreen' && $rootScope.selectedEmployee != null) {
                employeeId = $rootScope.selectedEmployee.EmpID;
            } 
            $scope.selectedPlannerType = { id: -1, test: 'Select Type' };

            iconHrService.invokeService().getPlannerFilter().$promise.then(function (response) {
                $scope.employee = response.EmployeeOptions;
                $scope.officeLocation = response.LocationOptions;
                $scope.department = response.DepartmentOptions;
            });

            iconHrService.invokeService().getPlanners({ fromScreen: fromScreen, employeeId: employeeId }).$promise.then(function (response) {
                var events = [];
                var locationId = 0;
                angular.forEach(response, function (value, key) {
                    events.push({
                        title: value.PlannedEventName, start: value.PlannedDate, description: value.PlannedEventName, color: '#af6dd0',
                        PlannerID: value.PlannerID,
                        PlannerCategoryID: value.PlannerCategoryID,
                        PlannedDate: value.PlannedDate,
                        CreatedBy: value.CreatedBy,
                        CreatedDate: value.CreatedDate,
                        EmpID: value.EmpID,
                        DepartmentId: value.DepartmentId,
                        LocationId:value.LocationId
                    });
                });
                $scope.eventSource = events;
                BuildCalender();
            });

        }

        $scope.onEventSave = function (myForm) {
            if (!myForm.$valid) {
                // alert('Enter valid data in all required fields');
                return;
            }
            if ($scope.planner.PlannedEventName !== null && $scope.planner.PlannedEventName.length != 0) {
                jQuery('#calender').fullCalendar('renderEvent', {
                    title: $scope.planner.PlannedEventName,
                    start: $scope.planner.PlannedDate,
                    color: '#af6dd0',
                    // end: end,
                    allDay: false,
                    //className: categoryClass
                }, true);
                jQuery('#event-modal').modal('hide');
            }
            else {
                alert('You have to give a title to your event');
                return;
            }



            if ($scope.selectedPlannerType != null) {
                $scope.planner.PlannerCategoryID = $scope.selectedPlannerType.id;
            }
            var employeeId = 0;
            var fromScreen = angular.element.find('#hdnScreenName')[0].value;
            if (fromScreen == 'employeeScreen' && $rootScope.selectedEmployee != null) {
                employeeId = $rootScope.selectedEmployee.EmpID;
                $scope.planner.EmpID = employeeId;
            }

            iconHrService.invokeService('').savePlanner($scope.planner).$promise.then(function (response) {
                    //window.location.reload();
                $scope.modalShown = true;
                    iconHrService.invokeService().getPlanners({ fromScreen: fromScreen, employeeId: employeeId }).$promise.then(function (response) {
                        var events = [];

                        $scope.planner = {
                            PlannedEventName: '',
                            PlannerCategoryID: null,
                            PlannedDate: null,
                        };
                        $scope.selectedPlannerType = {};
                        angular.forEach(response, function (value, key) {
                        events.push({
                            title: value.PlannedEventName, start: value.PlannedDate, description: value.PlannedEventName, color: '#af6dd0',
                            PlannerID: value.PlannerID,
                            CreatedBy: value.CreatedBy,
                            CreatedDate: value.CreatedDate,
                            EmpID: value.EmpID,
                            DepartmentId: value.DepartmentId,
                            LocationId: value.LocationId
                        });
                    });
                    jQuery('#calendar').fullCalendar('removeEventSource', $scope.eventSource);
                    $scope.eventSource = events;
                    jQuery('#calendar').fullCalendar('addEventSource', events);
                    jQuery('#calendar').fullCalendar('refetchEvents');

                });

                

            })
                .catch(function (error) {
                    $scope.modalShown = true;
                    $scope.Message = error.data;

                });
        };

        function onDrop(eventObj, date) {
            var $this = this;
            // retrieve the dropped element's stored Event Object
            var originalEventObject = eventObj.data('eventObject');
            var $categoryClass = eventObj.attr('data-class');
            // we need to copy it, so that multiple events don't have a reference to the same object
            var copiedEventObject = $.extend({}, originalEventObject);
            // assign it the date that was reported
            copiedEventObject.start = date;
            if ($categoryClass)
                copiedEventObject['className'] = [$categoryClass];
            // render the event on the calendar
            $this.$calendar.fullCalendar('renderEvent', copiedEventObject, true);
            // is the "remove after drop" checkbox checked?
            if ($('#drop-remove').is(':checked')) {
                // if so, remove the element from the "Draggable Events" list
                eventObj.remove();
            }
        }

        function BuildCalender() {
            jQuery('#calendar').fullCalendar({

                slotDuration: '00:15:00', /* If we want to split day time each 15minutes */
                minTime: '08:00:00',
                maxTime: '19:00:00',
                defaultView: 'month',
                handleWindowResize: true,
                height: jQuery(window).height() - 200,
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay'
                },
                events: $scope.eventSource,
                editable: true,
                droppable: true, // this allows things to be dropped onto the calendar !!!
                eventLimit: true, // allow "more" link when too many events
                selectable: true,
                drop: function (date) { onDrop(jQuery(this), date); },
                select: function (start, end, allDay) {
                    jQuery('#event-modal').modal('show');
                    $scope.planner.PlannedDate = moment(new Date(start)).format("MM-DD-YYYY");
                    //$this.onSelect(moment(new Date(start)).format("MM-DD-YYYY"), end, allDay);
                },
                eventClick: function (calEvent, jsEvent, view) {
                     onEventClick(calEvent, jsEvent, view);
                }

            });
        }

        function onEventClick(calEvent, jsEvent, view) {
            $this = this;
            $ = jQuery;
            var $this = this;
            //var form = $("<form></form>");
            //form.append("<label>Change event name</label>");
            // form.append("<div class='input-group'><input class='form-control' type=text value='" + calEvent.title + "' /><span class='input-group-btn'><button type='submit' class='btn btn-success waves-effect waves-light'><i class='fa fa-check'></i> Save</button></span></div>");
            $('#txtEventName').val(calEvent.title);
            $('#event-updatemodal').modal({
                backdrop: 'static'
            });
            $('#event-updatemodal').find('.delete-event').show().end().find('.save-event').hide().end()
                .find('.modal-body').empty().prepend('').end().find('.delete-event').unbind('click').click(function() {
                    $('#calendar').fullCalendar('removeEvents',
                        function (ev) {
                            if (ev._id == calEvent._id)
                                iconHrService.invokeService('').deletePlanner({ id: calEvent.PlannerID }).$promise.then(function (response) {
                                        $scope.modalShown = true;
                                        $scope.Message = 'Successfully Deleted';
                                })
                                .catch(function (error) {
                                    alert(error.data);
                                });

                            return (ev._id == calEvent._id);
                            // TODO delete api call build planner model

                        });
                    $('#event-updatemodal').modal('hide');
                });
            //$('#event-updatemodal').find('#form').on('submit', function () {
            $scope.onUpdate = function (myForm) {
                if (!myForm.$valid) {
                    // alert('Enter valid data in all required fields');
                    return;
                }
            // calEvent.title = form.find("input[type=text]").val();
            calEvent.title = $('#txtEventName').val();
            $('#calendar').fullCalendar('updateEvent', calEvent);
            // TODO update api call 
            var model = {
                PlannerID: calEvent.PlannerID,
                PlannedEventName: calEvent.title,
                PlannerCategoryID: calEvent.PlannerCategoryID,
                PlannedDate: calEvent.PlannedDate,
                CreatedBy: calEvent.CreatedBy,
                CreatedDate: calEvent.CreatedDate,
                EmpID: calEvent.EmpID,
                DepartmentId: calEvent.DepartmentId
            };

                iconHrService.invokeService('').updatePlanner(model).$promise.then(function (response) {
                        $scope.modalShown = true;
                    $scope.Message = 'Successfully Updated';
                })
                .catch(function(error) {
                    alert(error.data);
                });

            $('#event-updatemodal').modal('hide');
            return false;
        }

        //});
        }

        $scope.onFilter = function () {
            $scope.open = false;
           
            iconHrService.invokeService().getPlannersByFilters({
                locations: $scope.selectedLocations,
                departments: $scope.selectedDepartments,
                employees: $scope.selectedEmployees
            }).$promise.then(function (response) {
                var events = [];
                angular.forEach(response, function (value, key) {
                    events.push({
                        title: value.PlannedEventName, start: value.PlannedDate, description: value.PlannedEventName, color: '#af6dd0',
                        PlannerID: value.PlannerID,
                        CreatedBy: value.CreatedBy,
                        CreatedDate: value.CreatedDate,
                        EmpID: value.EmpID,
                        DepartmentId: value.DepartmentId,
                        LocationId: value.LocationId
                    });
                });
                jQuery('#calendar').fullCalendar('removeEventSource', $scope.eventSource);
                $scope.eventSource = events;
                jQuery('#calendar').fullCalendar('addEventSource', events);
                jQuery('#calendar').fullCalendar('refetchEvents');
            });

        }

        $scope.onClearFilter = function () {
            $scope.selectedLocations = [];
            $scope.selectedDepartments = [];
            $scope.selectedEmployees = [];
            $scope.onFilter();
        }

        $scope.openDropdown = function () {
            alert('open drop down');
            $scope.open = !$scope.open;
        };
    }
})();