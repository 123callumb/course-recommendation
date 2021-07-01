import { Radio, RadioGroup, Stack } from "@chakra-ui/react";
import React from "react";
import { connect } from "react-redux";
import Answer from "../../Models/Answer";
import { AnswerSet } from "../../Store/AnswerStore";
import { AppState } from "../../Store/reducer";
import { SetAnswerSet } from "../../Store/AnswerStore";

interface SingleRadioComp_Props {
    sectionID: number;
    answers: Answer[];
    answerSet?: AnswerSet;
    SetAnswerSet?: typeof SetAnswerSet;
}

class SingleRadioQuestion_Comp extends React.Component<SingleRadioComp_Props> {
    constructor(props: SingleRadioComp_Props) {
        super(props);
    }

    render() {
        return <RadioGroup value={this.props.answerSet?.AnswerID.toString()} onChange={(nextVal: string) => this.props.SetAnswerSet(this.props.sectionID, parseInt(nextVal))} defaultChecked={false}>
            <Stack spacing="3" mt="3">
                {this.props.answers.map(e =>
                    <Radio size="md" key={e.AnswerID} value={e.AnswerID.toString()}>
                        {e.Text}
                    </Radio>)}
            </Stack>
        </RadioGroup>
    }
}

export default connect((state: AppState, props: SingleRadioComp_Props): SingleRadioComp_Props => ({
    ...props
}), {
    SetAnswerSet
})(SingleRadioQuestion_Comp);