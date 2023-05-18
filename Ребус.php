<html>
	<form method = "post">
		<p>
			<input placeholder = "Введите первое слово" name = "first">
		</p>
		<p>
			+
		</p>
		<p>
			<input placeholder = "Введите второе слово" name = "second">
		</p>
		<p>
			=
		</p>
		<p>
			<input placeholder = "Ответ" name = "third">
		</p>
		<p>
			<button name="btn">Нажми</button>
		</p>
	</form>
</html>

<?php
	function calculation($array, $numbers, $count, $first, $second, $third){
		if($count == count($array)){
			$sum1 = 0;
			$sum2 = 0;
			$sum3 = 0;
			for($i = 0; $i < strlen($first); $i++){
				for($j = 0; $j < count($array); $j++){
					if($first[$i] == $array[$j][0]){
						$sum1 +=  $array[$j][1] * 10 ** (strlen($first) - $i - 1);
					}
				}
			}
			for($i = 0; $i < strlen($second); $i++){
				for($j = 0; $j < count($array); $j++){
					if($second[$i] == $array[$j][0]){
						$sum2 +=  $array[$j][1] * 10 ** (strlen($second) - $i - 1);
					}
				}
			}
			for($i = 0; $i < strlen($third); $i++){
				for($j = 0; $j < count($array); $j++){
					if($third[$i] == $array[$j][0]){
						$sum3 += $array[$j][1] * 10 ** (strlen($third) - $i - 1);
					}
				}
			}
			if($sum1 + $sum2 == $sum3){
				#print_r($array);
				echo $sum1;
				echo "+";
				echo $sum2;
				echo "=";
				echo $sum3;
				?>
				<html>
				<p>
				</p>
				</html>
				<?php
				return;
			}
			else{
				return;
			}
		}
		for($i = 0; $i < count($numbers); $i++){
			$c = 0;
			for($j = 0; $j < count($array); $j++){
				if($array[$j][1] != $numbers[$i]){
					$c++;
				}
			}
			if($c == count($array)){
				$array[$count][1] = $numbers[$i];
				calculation($array, $numbers, $count + 1, $first, $second, $third);
			}
		}
	}
	if(isset($_POST["btn"])){
		$first = $_POST["first"];
		$second = $_POST["second"];
		$third = $_POST["third"];
		$s = $_POST["first"];
		$s .= $_POST["second"];
		$s .= $_POST["third"];
		$array = array();
		for($i = 0; $i < strlen($s); $i++){
			if(!in_array(array($s[$i], "n"), $array)){
				array_push($array, array($s[$i], "n"));
			}
		}
		if(count($array) > 10){
			echo "Пример некорректен!";
		}
		else{
			$numbers = array(0, 1, 2, 3, 4, 5, 6, 7, 8, 9);
			calculation($array, $numbers, 0, $first, $second, $third);
		}
	}
?>