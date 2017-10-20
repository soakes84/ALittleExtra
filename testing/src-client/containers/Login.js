import React, { Component } from 'react';
import { StaggeredMotion, spring } from 'react-motion';


const colors = [
   '#B9F6CA',
   '#69F0AE',
   '#00E676',
   '#00C853'
]

const Box = (props) => {
   const styles = {
      flexBasis: `${props.width}%`,
      background: `${props.bgColor}`
   }
   return (
      <div className="box" style={styles}></div>
   )
}
const LoginWrapper = (props) => {
   return (
      <div className="columns small-12 main-bg grid-x align-middle align-center">
         <div className="header-content small-5 columns text-center">
            <h3>Muncher</h3>
            <p>Connecting Nonprofits with Local food Sources</p>
         </div>
      </div>
   )
}

export default class Login extends Component {
   render(){
      return(
         <StaggeredMotion
            defaultStyles={[
               { width: 100 },
               { width: 100 },
               { width: 100 },
            ]}
            styles={(prevStyles) =>
            [   { width: spring(0) },
               { width: spring(prevStyles[0].width) },
               { width: spring(prevStyles[1].width) }
            ]}

         >
               {(styles) => (
                  <div className="grid-y" style={{width: '100vw', height: '100vh', flexFlow: 'nowrap', flexDirection: 'column'}}>
                     <Box bgColor={colors[0]} width={styles[0].width} />
                     <Box bgColor={colors[1]} width={styles[1].width} />
                     <Box bgColor={colors[2]} width={styles[2].width} />
                     <LoginWrapper/>
                  </div>
               )}

         </StaggeredMotion>

      )
   }
}
