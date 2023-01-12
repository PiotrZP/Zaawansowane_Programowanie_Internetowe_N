import { NavigateFunction, Params } from "react-router";

export interface ICrudProps {
  navigate: NavigateFunction;
  params: Readonly<Params<string>>;
}
