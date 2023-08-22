import store from "../store";
import { append, destroy, destroyAll } from "../store/modal.js";
import { useSelector } from "react-redux";

export const useModals = () => useSelector((state) => state.modal.modals);

export const createModal = (name, data = false) =>
  store.dispatch(append({ name, data }));

export const destroyModal = () => store.dispatch(destroy());

export const destroyAllModal = () => store.dispatch(destroyAll());
