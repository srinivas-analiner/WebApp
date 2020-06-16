//---Thread sleep function--------------------------
function wait(ms) {
    var start = new Date().getTime();
    var end = start;
    while (end < start + ms) {
        end = new Date().getTime();
    }
}

function PostsyncData(url, Parameters, $Control, onSuccessCall, $HideControl) {
    if (typeof $HideControl === "undefined" || $HideControl === null) {
        $HideControl = true;
    }
    j.ajax({
        url: url,
        type: 'POST',
        data: Parameters,
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        cache: false,
        beforeSend: function () {
            $Control.css('cursor', 'not-allowed');
            $Control.prop("disabled", true);
            if ($HideControl)
                $Control.hide();
        },
        complete: function () {
            if ($HideControl)
                $Control.show();
            $Control.prop("disabled", false);
            $Control.css('cursor', 'pointer');
        },
        success: function (data) {
            onSuccessCall(data);
        },
        error: function () {
            var data = "Error";
            onSuccessCall(data);
        }
    });
}

function PostsyncFileUpload(url, Parameters, $Control, onSuccessCall, $HideControl) {
    if (typeof $HideControl === "undefined" || $HideControl === null) {
        $HideControl = true;
    }
    j.ajax({
        url: url,
        type: "POST",
        contentType: false,
        processData: false,
        data: Parameters,
        cache: false,
        beforeSend: function () {
            $Control.css('cursor', 'not-allowed');
            $Control.prop("disabled", true);
            if ($HideControl)
                $Control.hide();
        },
        complete: function () {
            if ($HideControl)
                $Control.show();
            $Control.prop("disabled", false);
            $Control.css('cursor', 'pointer');
        },
        success: function (data) {
            onSuccessCall(data);
        },
        error: function () {
            var data = "Error";
            onSuccessCall(data);
        }
    });
}

function PostasyncData(url, Parameters, $Control, onSuccessCall, $HideControl) {
    if (typeof $HideControl === "undefined" || $HideControl === null) {
        $HideControl = true;
    }
    j.ajax({
        url: url,
        type: 'POST',
        data: Parameters,
        timeout: 30000,
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        cache: false,
        async: false,
        beforeSend: function () {
            $Control.css('cursor', 'not-allowed');
            $Control.prop("disabled", true);
            $Control.hide();
        },
        complete: function () {
            $Control.prop("disabled", false);
            $Control.css('cursor', 'pointer');
            $Control.show();
        },
        success: function (data) {
            onSuccessCall(data);
        },
        error: function () {
            var data = "Error";
            onSuccessCall(data);
        }
    });
}

function FillDropDown(urlPath, Parameters, $dropDown) {
    j.ajax({
        url: urlPath,
        type: 'POST',
        data: Parameters,
        async: false,
        timeout: 30000,
        contentType: 'application/json; charset=utf-8',
        beforeSend: function () {
            $dropDown.hide();
            $dropDown.prop("disabled", true);
        },
        complete: function () {
            $dropDown.show();
            $dropDown.prop("disabled", false);
        },
        success: function (values) {
            $dropDown.find('option').remove();
            for (var i = 0; i < values.length; i++) {
                $dropDown.append("<option>" + values[i] + "</option>");
            }
            $dropDown[0].selectedIndex = -1;
        },
        error: function () {

        }
    });
}

function ValidateForm22($sel) {
    var fail = false;
    var FirstField;

    $sel.find('input[type=text]').each(function () {
        var label = j(this).siblings('label').text();
        if (label.indexOf("*") != -1 && j(this).val() === "") {
            j(this).parent('div').append('<label class="warning col-md-12 col-sm-12 col-xs-12 col-lg-12" style="color:red;font-size:0.8rem;">This Field Is Required</label>');
            if (!fail) {
                FirstField = j(this);
            }
            fail = true;
        }
    });

    $sel.find('input[type=password]').each(function () {
        var label = j(this).siblings('label').text();
        if (label.indexOf("*") != -1 && j(this).val() === "") {
            j(this).parent('div').append('<label class="warning col-md-12 col-sm-12 col-xs-12 col-lg-12" style="color:red;font-size:0.8rem;">This Field Is Required</label>');
            if (!fail) {
                FirstField = j(this);
            }
            fail = true;
        }
    });

    $sel.find('input[type=email]').each(function () {
        var label = j(this).siblings('label').text();
        if (label.indexOf("*") != -1 && j(this).val() === "") {
            j(this).parent('div').append('<label class="warning col-md-12 col-sm-12 col-xs-12 col-lg-12" style="color:red;font-size:0.8rem;">This Field Is Required</label>');
            if (!fail) {
                FirstField = j(this);
            }
            fail = true;
        }
    });

    $sel.find('input[type=number]').each(function () {
        var label = j(this).siblings('label').text();
        if (label.indexOf("*") != -1 && j(this).val() === "") {
            j(this).parent('div').append('<label class="warning col-md-12 col-sm-12 col-xs-12 col-lg-12" style="color:red;font-size:0.8rem;">This Field Is Required</label>');
            if (!fail) {
                FirstField = j(this);
            }
            fail = true;
        }
    });

    $sel.find('select').each(function () {
        var label = j(this).siblings('label').text();
        if (label.indexOf("*") != -1 && (j(this).val() === "" || j(this).val() === null)) {
            j(this).parent('div').append('<label class="warning col-md-12 col-sm-12 col-xs-12 col-lg-12" style="color:red;font-size:0.8rem;">This Field Is Required</label>');
            if (!fail) {
                FirstField = j(this);
            }
            fail = true;
        }
    });

    $sel.find('textarea').each(function () {
        var label = j(this).siblings('label').text();
        if (label.indexOf("*") != -1 && j(this).val() === "") {
            j(this).parent('div').append('<label class="warning col-md-12 col-sm-12 col-xs-12 col-lg-12" style="color:red;font-size:0.8rem;">This Field Is Required</label>');
            if (!fail) {
                FirstField = j(this);
            }
            fail = true;
        }
    });
    if (fail) {
        FirstField.focus();
    }
    return fail;
}

function AppendPager($tblPager, TCount, CPage, btnId) {
    if (typeof btnId === "undefined" || btnId === null) {
        btnId = "btnNumeric";
    }
    $tblPager.empty();
    var ss2 = "";
    if (TCount > 1) {
        if (TCount > 5) {
            if (CPage >= 4) {
                var cc = TCount;
                var ccTemp = CPage;
                if (ccTemp > (cc - 2)) {
                    ccTemp = parseInt(cc - 2);
                }
                for (var i = ccTemp - 2; i < (ccTemp + 3); i++) {
                    if (i >= TCount) {
                        break;
                    }
                    ss2 += '<td data-title="N"> <button class="btnNumeric" type="button" id="' + btnId + '" class="btn btn-sm">' + (i + 1) + '</button></td>';
                }
            }
            else {

                for (var i = 0; i < 5; i++) {
                    ss2 += '<td data-title="N"> <button class="btnNumeric" type="button" id="' + btnId + '" class="btn btn-sm">' + (i + 1) + '</button></td>';
                }
            }
            $tblPager.append('<tr>' + ss2 + '</tr>');
        }
        else {
            for (var i = 0; i < TCount; i++) {
                ss2 += '<td data-title="N"> <button class="btnNumeric" type="button" id="' + btnId + '" class="btn btn-sm">' + (i + 1) + '</button></td>';
            }
            $tblPager.append('<tr>' + ss2 + '</tr>');
        }
        //var id = "#" + btnId;
        Pager(TCount, CPage, $tblPager, btnId);
    }
}

function Pager(TCount, CPage, $tblPager, btnId) {
    var $tds = null;
    if (TCount > 5 && CPage < (TCount - 2)) {
        $tds = null;
        if (CPage == 0) {
            $tblPager.find('tr').each(function () {
                $tds = j(this).find("td:eq(0)");
            });
        }
        else
            if (CPage == 1) {
                $tblPager.find('tr').each(function () {
                    $tds = j(this).find("td:eq(1)");
                });
            }
            else
                if (CPage == 2) {
                    $tblPager.find('tr').each(function () {
                        $tds = j(this).find("td:eq(2)");
                    });
                }
                else
                    if (CPage == 3) {
                        $tblPager.find('tr').each(function () {
                            $tds = j(this).find("td:eq(3)");
                        });
                    }
        if ($tds != null) {
            $tds.find("#" + btnId).css("border", "none");
            $tds.find("#" + btnId).css("background", "#616161");
            $tds.find("#" + btnId).css("box-shadow", "inset 0px 0px 8px rgba(0,0,0, .5), 0px 1px 0px rgba(255,255,255, .8)");
            $tds.find("#" + btnId).css("color", "#f0f0f0");
            $tds.find("#" + btnId).css("text-shadow", "0px 0px 3px rgba(0,0,0, .5)");
            $tds.find("#" + btnId).blur();
        }
    }
    else {
        $tds = null;
        if (CPage == 0) {
            $tblPager.find('tr').each(function () {
                $tds = j(this).find("td:eq(0)");
            });
        }
        else
            if (CPage == 1) {
                $tblPager.find('tr').each(function () {
                    $tds = j(this).find("td:eq(1)");
                });
            }
            else
                if (CPage == 2) {
                    $tblPager.find('tr').each(function () {
                        $tds = j(this).find("td:eq(2)");
                    });
                }
                else
                    if (CPage == 3) {
                        $tblPager.find('tr').each(function () {
                            $tds = j(this).find("td:eq(3)");
                        });
                    }
        if ($tds != null) {
            $tds.find("#" + btnId).css("border", "none");
            $tds.find("#" + btnId).css("background", "#616161");
            $tds.find("#" + btnId).css("box-shadow", "inset 0px 0px 8px rgba(0,0,0, .5), 0px 1px 0px rgba(255,255,255, .8)");
            $tds.find("#" + btnId).css("color", "#f0f0f0");
            $tds.find("#" + btnId).css("text-shadow", "0px 0px 3px rgba(0,0,0, .5)");
            $tds.find("#" + btnId).blur();
        }
    }

    if (TCount == 5) {
        if (CPage == 4) {
            $tblPager.find('tr').each(function () {
                var $tds = j(this).find("td:eq(4)");
                $tds.find("#" + btnId).css("border", "none");
                $tds.find("#" + btnId).css("background", "#616161");
                $tds.find("#" + btnId).css("box-shadow", "inset 0px 0px 8px rgba(0,0,0, .5), 0px 1px 0px rgba(255,255,255, .8)");
                $tds.find("#" + btnId).css("color", "#f0f0f0");
                $tds.find("#" + btnId).css("text-shadow", "0px 0px 3px rgba(0,0,0, .5)");
                $tds.find("#" + btnId).blur();
            });
        }
    }
    if (TCount > 5 && CPage <= (TCount)) {
        $tds = null;
        if (CPage >= 4 && CPage > (TCount - 2)) {
            if (CPage == (TCount - 1)) {
                $tblPager.find('tr').each(function () {
                    $tds = j(this).find("td:eq(3)");
                });
            }
            else {
                $tblPager.find('tr').each(function () {
                    $tds = j(this).find("td:eq(4)");
                });
            }
        }
        else
            if (CPage >= 4) {
                $tblPager.find('tr').each(function () {
                    $tds = j(this).find("td:eq(2)");
                });
            }
        if ($tds != null) {
            $tds.find("#" + btnId).css("border", "none");
            $tds.find("#" + btnId).css("background", "#616161");
            $tds.find("#" + btnId).css("box-shadow", "inset 0px 0px 8px rgba(0,0,0, .5), 0px 1px 0px rgba(255,255,255, .8)");
            $tds.find("#" + btnId).css("color", "#f0f0f0");
            $tds.find("#" + btnId).css("text-shadow", "0px 0px 3px rgba(0,0,0, .5)");
            $tds.find("#" + btnId).blur();
        }
    }
}

function ValidateNumber(evt) {
    // var evt = (e) ? e : window.event;
    // var charCode = (evt.keyCode) ? evt.keyCode : evt.which;
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
};

/**
* detect IE
* returns version of IE or false, if browser is not Internet Explorer
*/
function detectIE() {
    var ua = window.navigator.userAgent;

    var msie = ua.indexOf('MSIE ');
    if (msie > 0) {
        // IE 10 or older => return version number
        return parseInt(ua.substring(msie + 5, ua.indexOf('.', msie)), 10);
    }

    var trident = ua.indexOf('Trident/');
    if (trident > 0) {
        // IE 11 => return version number
        var rv = ua.indexOf('rv:');
        return parseInt(ua.substring(rv + 3, ua.indexOf('.', rv)), 10);
    }

    var edge = ua.indexOf('Edge/');
    if (edge > 0) {
        // Edge (IE 12+) => return version number
        return parseInt(ua.substring(edge + 5, ua.indexOf('.', edge)), 10);
    }

    // other browser
    return false;
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

function fnc(value, min, max) {
    if (parseInt(value) < min || isNaN(value))
        return min;
    else if (parseInt(value) > max)
        return max;
    else return value;
}

// js prototype
if (typeof (Number.prototype.isBetween) === "undefined") {
    Number.prototype.isBetween = function (min, max, notBoundaries) {
        var between = false;
        if (notBoundaries) {
            if ((this < max) && (this > min)) between = true;
            //alert('notBoundaries');
        } else {
            if ((this <= max) && (this >= min)) between = true;
            //alert('Boundaries');
        }
        //alert('here');
        return between;
    }
}

String.prototype.bool = function () {
    return strToBool(this);
};

function strToBool(s) {
    // will match one and only one of the string 'true','1', or 'on' rerardless
    // of capitalization and regardless off surrounding white-space.
    //
    regex = /^\s*(true|1|on)\s*$/i

    return regex.test(s);
}

function padleft(str, max) {
    str = str.toString();
    return str.length < max ? padleft("0" + str, max) : str;
}

function UserGuide() {
    PostsyncData("/Json/PrintReview", {}, j(this), ViewUserGuide, false);
}

function ViewUserGuide(response) {
    if (response.Result == "Sucess") {
        window.open('/Home/UserGuide', '_blank');
        return false;
    }
}