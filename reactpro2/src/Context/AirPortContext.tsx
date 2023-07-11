import { createContext } from "react";
import { useSingalR } from "../Hooks/useSignalR";
import { IStation } from "../Models/IStation";
import { useSerivce } from "../Hooks/useService";
import { IFlightHistory } from "../Models/IFlightHistory";

export const AirPortContext = createContext<IAirPortContext>(
  0 as any as IAirPortContext
);
interface IProps {
  children: any;
}
export const AirPortProvider = ({ children }: IProps) => {
  const signalR = useSingalR();
  const service = useSerivce();

  return (
    <>
      <AirPortContext.Provider value={{ ...signalR, ...service }}>
        {children}
      </AirPortContext.Provider>
    </>
  );
};

export interface IAirPortContext {
  // signalR
  dataList: IStation[];

  // service
  flightHistory: IFlightHistory[];
  getFlightHistory: () => void;
}
