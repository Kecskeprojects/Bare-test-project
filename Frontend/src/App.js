import './App.css';
import config from './config.json';

function App() {
	function GetTranslation(originalString, translationLanguage){
		originalString = document.getElementById("original").value;
		translationLanguage = document.getElementById("languages").value;

		if(originalString === ""){
			alert("Empty textbox, nothing to translate!");
			return;
		}

		fetch(`${config.baseUrl}?originalString=${originalString}&translationLanguage=${translationLanguage}`,)
        .then((res) => {
			if(!res.ok){
				throw new Error("Unexpected error!\nStatus code:" + res.status);
			}
			else return res.json();
		})
         .then((data) => {
			if(data.translation == null){
				alert(data.error);
			}
			else{
				document.getElementById("result").value = data.translation;
			}
         })
         .catch((err) => {
            alert(err);
         });
	}

  	return (
    	<div className="app">
			<div className="container">
				<div className="translateBlocks">
				<textarea className="bigInput" type="text" id="original" placeholder="Write here"></textarea>
				</div>
				<div className="translateBlocks">
					<div className="languageContainer">
						<select id="languages" className="languageSelect" title="languages" onChange={GetTranslation}>
							{config.languages.map((language, i) => (
								<option key={i} value={language}>{language}</option>
							))}
						</select>
					</div>
					<textarea className="bigInput" type="text" id="result" placeholder="Translation here"></textarea>
				</div>
				<div>
					<input className="translateButton" type="button" onClick={GetTranslation} value="Translate"></input>
				</div>
			</div>
		</div>
	);
}

export default App;
