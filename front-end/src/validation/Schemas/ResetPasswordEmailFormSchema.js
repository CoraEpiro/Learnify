import Yup from "../validation-localization.js";

export const ResetPasswordEmailFormSchema = Yup.object().shape({
  email: Yup.string().required().email(),
});
