import { Flight } from "../Flight/Flight";
import "./Station.css";

export const Station = ({ stationId, flightId }: IProps) => {
  return (
    <div className="Station">
      <div className="station-num">{stationId}</div>
      {
        flightId != 0 && <Flight flightId={flightId} /> //if flight id is not 0
      }
    </div>
  );
};

interface IProps {
  stationId: number;
  flightId: number;
}
