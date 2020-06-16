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
        beforeSend: function () {
            $Control.hide();
        },
        complete: function () {
            $Control.show();
        },
        success: function (data) {
            onSuccessCall(data);
        },
        async: false,
        error: function () {
            var data = "Error";
            onSuccessCall(data);
        }
    });
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


function UpdateLoginDiv(response) {
    if (response.Result == "Sucess") {
        j(".divLogin").empty();
        j(".divLogin").append(response.OutData);
    }
}
