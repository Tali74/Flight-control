import { useState } from "react";
import { IFlightHistory } from "../Models/IFlightHistory";
import axios from "axios";

export const useSerivce = () => {
  const [flightHistory, setFlightHistory] = useState<IFlightHistory[]>([]);

  const url = "http://localhost:5001/api/Airport/FlightHistory";

  const getFlightHistory = () => {
    axios.get(url).then((res) => {
    // console.log(res.data);
      setFlightHistory(res.data);
    });
  };

  return {
    flightHistory,
    getFlightHistory,
  };
};
