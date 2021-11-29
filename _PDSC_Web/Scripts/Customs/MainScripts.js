
function Show_backbtn()
{
	$('#btn_back').css("display", "block");
}

function Hide_backbtn()
{
	$('#btn_back').css("display", "none");
}

function Back_Button() //history back
{
	window.history.back();
}
  function Alert_Success(msg)
	{
		swal("Good job!", msg, "success");
    }
	 function Alert_Error(tital,msg)
	   {
		 swal({
			 title: tital,
			 text: msg,
			 type: "warning"//"error"
		 });
	  }
	function Alert_warning(tital,msg)
	{
		   swal(tital, msg, "warning");
}

function Alert_Ok(tital, msg, status,url)
{
	if (status)
	{
		setTimeout(function () {
			swal({
				title: tital,
				text: msg,
				type: "success"
			},
				function () {
					
					window.location.href = url;
				});
		}, 500);
	}
	else
	{
		setTimeout(function () {
			swal({
				title: tital,
				text: msg,
				type: "error"
			},
				function ()
				{
					window.location.href = url;
				});
		}, 500);
	}
}

function changeFormat_date(var_date)
{
	var data_date = $(var_date).val();
	if (data_date == null || data_date == "") {

	}
	else {

		$(var_date).val(moment(data_date).format("YYYY-MM-DD"));
    }
}


function disable_stage(Stage, IsRole) {
	//console.log(Stage + "   " + IsRole);
	if (Stage == "Delivery") {
		$('#install_btn').prop('disabled', true);
		$('#install_btn').css("color", "grey");
		$('#install_btn').css("border", "1px dashed grey");

		$('#powerSupply_btn').prop('disabled', true);
		$('#powerSupply_btn').css("color", "grey");
		$('#powerSupply_btn').css("border", "1px dashed grey");

		$('#testing_btn').prop('disabled', true);
		$('#testing_btn').css("color", "grey");
		$('#testing_btn').css("border", "1px dashed grey");

		$('#qc_btn').prop('disabled', true);
		$('#qc_btn').css("color", "grey");
		$('#qc_btn').css("border", "1px dashed grey");

		$('#ho_btn').prop('disabled', true);
		$('#ho_btn').css("color", "grey");
		$('#ho_btn').css("border", "1px dashed grey");

		if (IsRole != "1") {
			$('#submit_btn').prop('disabled', true);
			$('#submit_btn').css("color", "grey");
			$('#submit_btn').css("border", "1px dashed grey");
		}

		$('#close_btn').prop('disabled', true);
		$('#close_btn').css("color", "grey");
		$('#close_btn').css("border", "1px dashed grey");

	}
	else if (Stage == "Power Supply") {
		$('#testing_btn').prop('disabled', true);
		$('#testing_btn').css("color", "grey");
		$('#testing_btn').css("border", "1px dashed grey");

		//$('#qc_btn').prop('disabled', true);
		//$('#qc_btn').css("color", "grey");
		//$('#qc_btn').css("border", "1px dashed grey");

		$('#ho_btn').prop('disabled', true);
		$('#ho_btn').css("color", "grey");
		$('#ho_btn').css("border", "1px dashed grey");

		if (IsRole != "1") {
			$('#submit_btn').prop('disabled', true);
			$('#submit_btn').css("color", "grey");
			$('#submit_btn').css("border", "1px dashed grey");
		}

		$('#close_btn').prop('disabled', true);
		$('#close_btn').css("color", "grey");
		$('#close_btn').css("border", "1px dashed grey");
	}
	else if (Stage == "QC") {
		$('#ho_btn').prop('disabled', true);
		$('#ho_btn').css("color", "grey");
		$('#ho_btn').css("border", "1px dashed grey");

		if (IsRole != "1") {
			$('#submit_btn').prop('disabled', true);
			$('#submit_btn').css("color", "grey");
			$('#submit_btn').css("border", "1px dashed grey");
		}

		$('#close_btn').prop('disabled', true);
		$('#close_btn').css("color", "grey");
		$('#close_btn').css("border", "1px dashed grey");
	}
	else if (Stage == "" && IsRole == "1") {
		$('#prepare_btn').prop('disabled', true);
		$('#prepare_btn').css("color", "grey");
		$('#prepare_btn').css("border", "1px dashed grey");

		$('#delivery_btn').prop('disabled', true);
		$('#delivery_btn').css("color", "grey");
		$('#delivery_btn').css("border", "1px dashed grey");

		$('#install_btn').prop('disabled', true);
		$('#install_btn').css("color", "grey");
		$('#install_btn').css("border", "1px dashed grey");

		$('#powerSupply_btn').prop('disabled', true);
		$('#powerSupply_btn').css("color", "grey");
		$('#powerSupply_btn').css("border", "1px dashed grey");

		$('#testing_btn').prop('disabled', true);
		$('#testing_btn').css("color", "grey");
		$('#testing_btn').css("border", "1px dashed grey");

		$('#qc_btn').prop('disabled', true);
		$('#qc_btn').css("color", "grey");
		$('#qc_btn').css("border", "1px dashed grey");

		$('#ho_btn').prop('disabled', true);
		$('#ho_btn').css("color", "grey");
		$('#ho_btn').css("border", "1px dashed grey");

		$('#close_btn').prop('disabled', true);
		$('#close_btn').css("color", "grey");
		$('#close_btn').css("border", "1px dashed grey");
	}
}

$('#DownlondFile_btn').click(function () {
	var ImgSrC = $('#PreviewImg').attr('src');

	var a = document.createElement("a"); //Create <a>
	a.href = ImgSrC; //Image Base64 Goes here
	a.download = "Image.png"; //File name Here
	a.click(); //Downloaded file
});

$('#DownlondFile_InformatioDefect_btn').click(function () {
	var ImgSrC = $('#PreviewImg-Download').attr('src');

	var a = document.createElement("a"); //Create <a>
	a.href = ImgSrC; //Image Base64 Goes here
	a.download = "Defect_Image.png"; //File name Here
	a.click(); //Downloaded file
});

