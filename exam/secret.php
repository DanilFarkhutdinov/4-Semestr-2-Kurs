<?php

require_once "common/Page.php";
use common\Page;
use common\DbHelper;

class secret extends Page
{
	
	protected function showContent(){
		$name = DbHelper::GetInstance()->getUserName($_SESSION['login']);
		print "<div>Приветствуем, ".$name."</div>";
		print "<div>Личный кабинет...</div>";
		$dbh = new DbHelper("localhost", 3306, "root", "");
		$img = $this->dbh->getImage();
        echo '<td>' . '<img src = "data:image/png;base64,' . base64_encode($img) . '" width = "550px" height = "550px"/>' . '</td>';
	}
}

(new secret())->show();


?>