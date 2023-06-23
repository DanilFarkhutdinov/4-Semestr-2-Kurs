<?php

require_once "common/Page.php";
use common\Page; // полное имя класса - позволяет сокращать до Page

class second extends Page // класс index расширяет класс Page
{
	
	protected function showContent(){
		print "<div>ОСНОВНОЙ КОНТЕНТ ВТОРОЙ СТРАНИЦЫ</div>";
	}
	
}

(new second())->show();

?>