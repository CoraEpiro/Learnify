import AccentLightButton from "../../buttons/accent-light-button/index.js";
import { destroyModal } from "../../../utils/modal.js";

const ModalCloseButton = () => {
  return (
    <div>
      <AccentLightButton click={destroyModal} title={"X"} />
    </div>
  );
};

export default ModalCloseButton;
