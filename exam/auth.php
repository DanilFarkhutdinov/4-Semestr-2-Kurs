<?php

require_once "common/Page.php";
use common\Page; // полное имя класса - позволяет сокращать до Page
use common\DbHelper;

class auth extends Page
{
	private $auth;
	
	public function __construct(){
		parent::__construct();
		if(isset($_REQUEST['exit'])){
			unset($_SESSION['login']);
			header("Location: /exam/auth.php");
		}
		else{
			$this->auth = $this->auth();
		}
	}
	
	protected function showContent(){
		?>
		<form method='post' action='auth.php'>
			<table class='authtable'>
				<tr>
					<td class="tdhead">Вход в аккаунт</td>
				</tr>
				<tr>
					<td><input class="tdlogin" type="text" size="30" maxlength="50" name="auth_login" placeholder="Логин"></td>
				</tr>
				<tr>
					<td><input class="tdpass" type="password" size="30" maxlength="50" name="auth_password" placeholder="Пароль"> </td>
				</tr>
				<tr>
					<td><input class="inputbtn" type="submit" value="Войти"></td>
				</tr>
				<tr>
					<td><a  class="regbtn" name='reg' href='reg.php'>Еще не зарегистрированы?</button></a>
				</tr>
				<?php
				if($this->auth === false){
					?>
					<tr>
						<td class="error">Неверно введены логин или пароль</td>
					</tr>
					<?php
				}
				?>
			</table>
		</form>
		<?php
	}
	
	private function auth(): ?bool{
		if(!isset($_POST['auth_login']) || !isset($_POST['auth_password']) || mb_strlen($_POST['auth_login']) < 3 || mb_strlen($_POST['auth_password']) < 3){
			return null;
		}
		$login = $_POST['auth_login'];
		$password = $_POST['auth_password'];
		$save_pwd = DbHelper::getInstance()->getUserPassword($login) ?? "";
		$auth = password_verify($password, $save_pwd);
		if($auth) {
			$_SESSION['login'] = $login;
			header("Location: /exam/secret.php");
		}
		else{
			unset($_SESSION['login']);
		}
		return $auth;
	}
	
}

(new auth())->show();
?>