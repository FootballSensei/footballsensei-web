import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { Matches } from "./components/Matches";
import { Match } from "./components/Match";
//import { Players } from "./components/Players";
//import { Teams } from "./components/Teams";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
    },

  {
      path: '/matches',
      element: <Matches />
    },

  {
      path: '/match/:id',
      element: <Match />
  }
  /*
  {
      path: '/teams',
      element: <Teams />
  },

  {
      path: '/players',
      element: <Players />
  }
  */

];

export default AppRoutes;
