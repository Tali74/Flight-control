import "./Flight.css";

export const Flight = ({ flightId }: IProps) => {
  return (
    <div className="Flight">
      <div>{flightId}</div>
    </div>
  );
};

interface IProps {
  flightId: number;
}
