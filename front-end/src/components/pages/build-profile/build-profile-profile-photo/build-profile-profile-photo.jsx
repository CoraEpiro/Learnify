import { createAvatar } from "@dicebear/core";
import { botttsNeutral } from "@dicebear/collection";
import PropTypes from "prop-types";

const BuildProfileProfilePhoto = ({ userName }) => {
  const avatar = createAvatar(botttsNeutral, { seed: userName, radius: 50 });

  const dataUri = avatar.toDataUriSync();

  return (
    <div className={"flex gap-4"}>
      {/*Profile Photo*/}
      <div>
        <img src={dataUri} alt="avatar" className={"w-20 rounded-lg"} />
      </div>

      <div className={"flex flex-col items-center gap-2"}>
        {/*Name*/}
        <p className={"text-xl"}>{name}</p>

        {/*Edit image*/}
        <button
          onClick={() => {}}
          className={
            "p-2 px-3  text-black  font-medium rounded-lg transition-all duration-500 bg-[#d6d6d6] hover:bg-[#a3a3a3] "
          }
        >
          <p>Edit profile image</p>
        </button>
      </div>
    </div>
  );
};

BuildProfileProfilePhoto.propTypes = {
  userName: PropTypes.string,
};

export default BuildProfileProfilePhoto;
