import { HubConnectionBuilder } from "@microsoft/signalr";
import { useEffect, useState } from "react";
import { IStation } from "../Models/IStation";

export const useSingalR = () => {
  const url = "http://localhost:5001/airport";
  const conection = new HubConnectionBuilder().withUrl(url).build();

  const [dataList, setDataList] = useState<IStation[]>([]);

  conection.on("RecieveStation", (text: string) => {
    const data1: IStation = JSON.parse(text);

    console.log(dataList);
    setDataList((p) => [...p, data1]);

  });
  useEffect(() => {
    conection.stop().then(() => {
      conection.start().then(() => {
        console.log("singalR conected");
      });
    });
    return () => {
      conection.stop().then(() => console.log("SingalR dissconected"));
    };
  }, []);

  return {
    dataList,
  };
};
