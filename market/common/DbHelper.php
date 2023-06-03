<?php
	
	namespace common;
	
	use Exception;
	use mysqli;
	
	Class DbHelper
	{
		private const dbName = "market";
		private static ?DbHelper $instance = null;
		private $conn;
		
		public static function getInstance($host = null, $port = null, $user = null, $pass = null): DbHelper{ //Функция возвращает значение типа DbHelper
			if(self::$instance == null) self::$instance = new DbHelper($host, $port, $user, $pass);
			return self::$instance;
		}
		
		private function __construct ($host, $port, $user, $pass){
			$this->conn = new mysqli();
			$this->conn->connect(
				hostname: $host,
				username: $user,
				password: $pass,
				database: self::dbName,
				port: $port
			);
			
		}
		public function saveUser(string $log, string $pass, string $name): void
		{
			$this->conn->query("INSERT INTO users (login, password, name) VALUES ('$log', '$pass', '$name')");
		}
		
		public function DeleteFromUser(): void 
		{
			$this->conn->query("DELETE FROM users");
		}
		
		public function GetPassword($login): array
		{
			$query = "SELECT * FROM users WHERE login = '$login'";
			$pass = $this->conn->query($query);
			$array = $pass->fetch_array();
			return $array;
		}
		
		public function GetLogin(): array{
			$query = "SELECT login FROM users";
			$log = $this->conn->query($query);
			$array = $log->fetch_all();
			return $array;
		}
		
		public function InsertIntoBasket($login, $product){
			$this->conn->query("INSERT INTO basket (login, product) VALUES ('$login', '$product')");
		}
		
		public function GetProduct(){
			$query = "SELECT * FROM basket";
			$product = $this->conn->query($query);
			$array = $product->fetch_all();
			return $array;
		}
		
		public function SelectProduct($login){
			$query = "SELECT product FROM basket WHERE login = '$login'";
			$product = $this->conn->query($query);
			$array = $product->fetch_all();
			return $array;
		}
		
		public function DeleteRow($login, $product){
			$this->conn->query("DELETE FROM basket WHERE login = '$login' AND product = '$product'");
		}
		
		public function UpdateCatalog($product){
			$this->conn->query("UPDATE catalog SET count = count - 1 WHERE product = '$product'");
		}
	}	
?>