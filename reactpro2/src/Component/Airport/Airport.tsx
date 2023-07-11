import { useContext, useEffect, useState } from "react";
import { IStation } from "../../Models/IStation";
import { Station } from "../Station/Station";
import "./Airport.css";
import { AirPortContext } from "../../Context/AirPortContext";

export const Airport = () => {
  const { dataList } = useContext(AirPortContext);

  const [stationList, setStationList] = useState<IStation[]>([
    { stationId: 1, flight: { flightId: 0 } },
    { stationId: 2, flight: { flightId: 0 } },
    { stationId: 3, flight: { flightId: 0 } },
    { stationId: 4, flight: { flightId: 0 } },
    { stationId: 5, flight: { flightId: 0 } },
    { stationId: 6, flight: { flightId: 0 } },
    { stationId: 7, flight: { flightId: 0 } },
    { stationId: 8, flight: { flightId: 0 } },
    { stationId: 9, flight: { flightId: 0 } },
  ]);

  const setStation = (sId: number, fId: number) => {
    if (sId < 1 || sId > 9) return;
    stationList[sId - 1].flight = { flightId: fId };
    setStationList((p) => [...p]);
  };

  const listHandle = () => {
    setTimeout(() => {
      const data = dataList.shift();
      if (data !== undefined) {
        console.log(
          `%cstation ${data.stationId} | flight ${data.flight.flightId}`,
          "color:green"
        );
        setStation(data.stationId, data.flight.flightId);
        if (dataList.length > 0) {
          listHandle();
        }
      }
    }, 20);
  };

  useEffect(() => {
    listHandle();
  }, [dataList]);

  return (
    <>
      <div className="stations">
        {stationList.map((station) => (
          <Station
            key={station.stationId}
            flightId={station.flight.flightId}
            stationId={station.stationId}
          />
        ))}
      </div>
    </>
  );
};
