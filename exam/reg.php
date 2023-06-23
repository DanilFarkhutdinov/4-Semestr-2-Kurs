<?php

require_once "common/Page.php";
use common\Page;
use common\DbHelper;

class reg extends Page
{
	private $auth;
	private $error;
	private $e_msg;
	
	public function __construct(){
		parent::__construct();
		if(isset($_POST['name'])){
			$this->error = $this->regUser();
		}
	}
	
	protected function showContent(){
		switch ($this->error){
			case 1:{
				$this->e_msg = "Неверный логин!";
				break;
			}
			case 2:{
				$this->e_msg = "Неверный пароль!";
				break;
			}
			case 3:{
				$this->e_msg = "Пароли не совпадают!";
				break;
			}
			case 4:{
				$this->e_msg = "Неверное имя пользователя!";
				break;
			}
			case -1:{
				$this->e_msg = "Заполните все поля формы!";
				break;
			}
			case -2:{
				$this->e_msg = "Логин занят!";
				break;
			}
		}
		?>
		<form method='post' action='reg.php'>
			<table class="regtable">
				<tr>
					<td class="tdheadreg">Регистрация</td>
				</tr>
				<tr>
					<td><input class="tdname" type="text" size="30" maxlength="50" name="name" value="<?php if(!empty($_POST['name'])) print($_POST['name']);?>" placeholder="Имя"></td>
				</tr>
				<tr>
					<td><input class="tdloginreg" type="text" size="30" maxlength="50" name="reg_login" value="<?php if(!empty($_POST['reg_login'])) print($_POST['reg_login']);?>" placeholder="Логин"></td>
				</tr>
				<tr>
					<td><input class="tdpasswordreg" type="password" size="30" maxlength="50" name="reg_password" value="<?php if(!empty($_POST['reg_password'])) print($_POST['reg_password']);?>" placeholder="Пароль"></td>
				</tr>
				<tr>
					<td><input class="tdreppassword" type="password" size="30" maxlength="50" name="reg_repeat_password" value="<?php if(!empty($_POST['reg_repeat_password'])) print($_POST['reg_repeat_password']);?>" placeholder="Повтор пароля"></td>
				</tr>
				<tr>
					<td><input class="sendbtn" type="submit" value="Зарегистрироваться"></td>
				</tr>
				<?php
				if ($this->error !== 0){
					?>
					<tr>
						<td class='error'><?php print($this->e_msg); ?></td>
					</tr>
					<?php
				}
				else{
					?>
					<tr>
						<td class='okey'>Регистрация прошла успешно</td>
					</tr>
					<?php
				}
				?>
			</table>
		</form>
		<?php
	}
	
	private function regUser(): int{
		$error = 0;
		if(!empty($_POST['reg_login']) && !empty($_POST['reg_password']) && !empty($_POST['name']) && !empty($_POST['reg_repeat_password'])){
			$login = htmlspecialchars($_POST['reg_login']);
			if(mb_strlen($login) < 4 || mb_strlen($login) > 30) $error = 1;
			$password = htmlspecialchars($_POST['reg_password']);
			if(mb_strlen($password) < 6 || mb_strlen($password) > 30) $error = 2;
			$password2 = htmlspecialchars($_POST['reg_repeat_password']);
			if($password !== $password2) $error = 3;
			$name = htmlspecialchars($_POST['name']);
			if(mb_strlen($name) < 2 || mb_strlen($password) > 100) $error = 4;
			if ($error === 0){
				$dbh = new DbHelper("localhost", 3306, "root", "");
				$hash = password_hash($password, PASSWORD_DEFAULT);
				if(!$dbh->saveUser($login, $hash, $name)){
					$error = -2;
				}
			}
		}
		else {
			$error = -1;
		}

		return $error;
	}
}

(new reg())->show();

?>