            function jsCheckSession() {

                if (parent.document.getElementById("opener").innerText != 'Login For Update') {

                    $.ajax({
                        type: "POST",
                        async: false,
                        url: "ws/WS_Permission.asmx/CheckSession",
                        dataType: "xml",

                        error: function (xhr) {

                            alert(xhr.responseText);
                            event.returnValue = false;
                            return;
                        },
                        success: function (msg) {
                            try {
                                if ($(msg).text() != 'true') {

                                    alert('因頁面閒置過久, 如需維護資料請再次登入！');
                                    window.parent.location.href = window.parent.location.href;
                                    return false;
                                }
                            }
                            catch (e) {

                                alert(e.message);
                            }
                        }
                    });
                }
            }