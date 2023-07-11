import "./App.css";
import { AirPortProvider } from "./Context/AirPortContext";
// import { useSingalR } from "./Hooks/useSignalR";
import { MainView } from "./Views/MainView/MainView";

function App() {
  // const { start } = useSingalR();

  return (
    <>
    <AirPortProvider>
      <MainView />
    </AirPortProvider>
      {/* <h1>Hi</h1>
    <button onClick={start}>start</button> */}
    </>
  );
}

export default App;
