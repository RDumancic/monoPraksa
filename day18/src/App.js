import './App.css';

function Plane(props){
  return(
    <p>{props.name} with {CalculatePower(props.thrust, props.velocity)} hp.</p>
  );
}

function CalculatePower(a,b){
  return a * b;
}

function Disclaimer(){
  return (
    <div>
      Don't take these values to heart, since they were made up.
    </div>
  );
}

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Plane name="mig" thrust={20} velocity={1800}/>
        <Plane name="P-47" thrust={5} velocity={350}/>
        <Plane name="Bf-109" thrust={5} velocity={500}/>
      </header>
      <footer className="App-footer">
        <Disclaimer/>
      </footer>
    </div>
  );
}

export default App;
