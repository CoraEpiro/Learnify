import modalData from "../modal.js";
import { useModals } from "../utils/modal.js";
import { nanoid } from "nanoid";

export default function Modal() {
  const modals = useModals();

  return (
    <div
      className={
        "w-full h-full fixed absolute inset-0 bg-black/50 flex items-center justify-center"
      }
    >
      {modals.map((modal) => {
        const m = modalData.find((m) => m.name === modal.name);

        return (
          <div key={nanoid()} className={"hidden last:block"}>
            <m.element data={modal.data} />
          </div>
        );
      })}
    </div>
  );
}
