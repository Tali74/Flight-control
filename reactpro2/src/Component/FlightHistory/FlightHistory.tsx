import { useContext, useEffect } from "react";
import "./FlightHistory.css";
import { AirPortContext } from "../../Context/AirPortContext";

const FlightHistory = () => {
  const { flightHistory, getFlightHistory } = useContext(AirPortContext);

  const dateToString = (dateTime: Date) => {
    let [date, time] = dateTime.toString().split("T");
    time = time.substring(0, 8);
    return `${date} ${time}`
  };

  useEffect(() => {
    getFlightHistory();
  }, []);

  return (
    <>
      <div className="FlightHistory">
        <button onClick={getFlightHistory}>Update History</button>

        <div className="table">
          <div className="t-head">
            <div className="row">
              <div className="col">id</div>
              <div className="col">flight id</div>
              <div className="col">enter time</div>
              <div className="col">exit time</div>
              <div className="col">state</div>
            </div>
          </div>

          <div className="t-body">
            {flightHistory.map((f) => (
              <div key={f.id} className="row">
                <div className="col">{f.id}</div>
                <div className="col">{f.flightId}</div>
                <div className="col">{dateToString(f.enterTime)}</div>
                <div className="col">{dateToString(f.exitTime)}</div>
                <div className="col">{f.state}</div>
              </div>
            ))}
          </div>
        </div>
      </div>
    </>
  );
};

export default FlightHistory;
