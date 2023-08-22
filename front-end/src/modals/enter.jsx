import PropTypes from "prop-types";
import ModalHeader from "../components/modals/modal-header/index.js";
import PrimaryAccentButton from "../components/buttons/primary-accent-button/index.js";
import PrimaryButton from "../components/buttons/primary-button/index.js";
import { useNavigate } from "react-router-dom";
import { destroyModal } from "../utils/modal.js";

export default function EnterModal() {
  const navigate = useNavigate();

  return (
    <div className={"w-[550px]"}>
      <ModalHeader title={"Log in to continue"} />
      <div
        className={
          "flex flex-col items-center justify-center gap-4 bg-white px-6 py-3 rounded-b-md"
        }
      >
        <p className={"text-sm"}>
          We&apos;re a place where coders share, stay up-to-date and grow their
          careers.
        </p>
        <div className={"w-full flex flex-col gap-1"}>
          <PrimaryAccentButton
            title={"Log in"}
            click={() => {
              navigate("/enter");
              destroyModal();
            }}
          />
          <PrimaryButton
            title={"Create Account"}
            click={() => {
              navigate("/enter?state=new-user");
              destroyModal();
            }}
          />
        </div>
      </div>
    </div>
  );
}

EnterModal.propTypes = {
  close: PropTypes.func,
};
