import { Airport } from "../../Component/Airport/Airport";
import FlightHistory from "../../Component/FlightHistory/FlightHistory";
import "./MainView.css";

export const MainView = () => {
  return (
    <>
      <h1>Airport Simulator</h1>
      <main>
        <Airport />
        <div>
          <FlightHistory />
        </div>
      </main>
    </>
  );
};
