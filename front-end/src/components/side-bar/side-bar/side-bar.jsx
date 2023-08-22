import SideBarNavTitle from "../side-bar-nav-title/index.js";
import SideBarNavHeader from "../side-bar-nav-header/index.js";
import BaseLinkButton from "../../buttons/base-link-button/index.js";

const SideBar = () => {
  return (
    <div className={"flex flex-col gap-3 "}>
      <div className={"flex flex-col gap-1"}>
        <SideBarNavHeader title={"Content Pages"} />
        <BaseLinkButton
          renderTitle={<SideBarNavTitle title={"Home"} iconName={"house"} />}
          startFlex={true}
        />
        <BaseLinkButton
          renderTitle={<SideBarNavTitle title={"Flow"} iconName={"flow"} />}
          startFlex={true}
        />
        <BaseLinkButton
          renderTitle={
            <SideBarNavTitle title={"Explore"} iconName={"explore"} />
          }
          startFlex={true}
        />
        <BaseLinkButton
          renderTitle={<SideBarNavTitle title={"Form"} iconName={"form"} />}
          startFlex={true}
        />
        <BaseLinkButton
          renderTitle={
            <SideBarNavTitle title={"Articles"} iconName={"articles"} />
          }
          startFlex={true}
        />
        <BaseLinkButton
          renderTitle={
            <SideBarNavTitle title={"Courses"} iconName={"courses"} />
          }
          startFlex={true}
        />
        <BaseLinkButton
          redirectUrl={"/categories"}
          renderTitle={
            <SideBarNavTitle title={"Categories"} iconName={"categories"} />
          }
          startFlex={true}
        />
        <BaseLinkButton
          renderTitle={
            <SideBarNavTitle title={"Leader Board"} iconName={"leader-board"} />
          }
          startFlex={true}
        />
      </div>

      <div className={"flex flex-col gap-1"}>
        <SideBarNavHeader title={"Platform Pages"} />

        <BaseLinkButton
          renderTitle={<SideBarNavTitle title={"FAQ"} iconName={"faq"} />}
          startFlex={true}
        />
        <BaseLinkButton
          renderTitle={<SideBarNavTitle title={"About"} iconName={"about"} />}
          startFlex={true}
        />
        <BaseLinkButton
          redirectUrl={"/code-of-conduct"}
          renderTitle={
            <SideBarNavTitle
              title={"Code Of Conduct"}
              iconName={"code-of-conduct"}
            />
          }
          startFlex={true}
        />
        <BaseLinkButton
          redirectUrl={"/contact"}
          renderTitle={
            <SideBarNavTitle title={"Contact"} iconName={"contact"} />
          }
          startFlex={true}
        />
        <BaseLinkButton
          redirectUrl={"/privacy"}
          renderTitle={
            <SideBarNavTitle title={"Privacy & Policy"} iconName={"privacy"} />
          }
          startFlex={true}
        />
        <BaseLinkButton
          redirectUrl={"/terms"}
          renderTitle={
            <SideBarNavTitle title={"Terms of use"} iconName={"terms"} />
          }
          startFlex={true}
        />
      </div>
    </div>
  );
};

export default SideBar;
