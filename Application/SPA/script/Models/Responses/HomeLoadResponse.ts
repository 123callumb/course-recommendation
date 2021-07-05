import { AnswerSet } from "../../Store/AnswerStore";
import Group from "./Group";

export default interface HomeLoadResponse {
    SessionAnswerSets: AnswerSet[]
    Groups: Group[];
}